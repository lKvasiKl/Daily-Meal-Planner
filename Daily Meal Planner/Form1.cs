#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Objects;
using Servise_Layer.Object;
using System.Windows.Forms;

namespace Daily_Meal_Planner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTreeViewProducts();

            FillTreeViewRation();
        }

        private void FillTreeViewProducts()
        {
            //Load Categories and Products
            Servise.SetPath(@"D:\The_3_semestr\Daily Meal Planner\Data_Layer\bin\Debug\net5.0\FoodProducts.xml");
            int i = 0;
            this.treeView1.ImageList = imageList1;
            this.treeView1.BeginUpdate();
            this.treeView1.Nodes.Clear();
            foreach (Category category in Servise.GetCategories())
            {
                this.treeView1.Nodes.Add(category.Name);
                this.treeView1.Nodes[i].ImageIndex = i;
                this.treeView1.Nodes[i].SelectedImageIndex = 25;
                this.treeView1.Nodes[i].Tag = category;
                int j = 0;
                foreach (Product product in Servise.GetProductsOf(category.Name))
                {
                    this.treeView1.Nodes[i].Nodes.Add(product.Name);
                    this.treeView1.Nodes[i].Nodes[j].ImageIndex = i;
                    this.treeView1.Nodes[i].Nodes[j].SelectedImageIndex = 25;
                    this.treeView1.Nodes[i].Nodes[j].Tag = product;
                    j++;
                }

                i++;
            }

            this.treeView1.EndUpdate();
        }

        private void FillTreeViewRation()
        {
            this.treeView2.BeginUpdate();
            this.treeView2.Nodes.Clear();
            this.treeView2.ImageList = imageList2;
            foreach (MealTime meal in Servise.GetRation())
            {
                AddMealTime(meal);
            }

            this.treeView2.EndUpdate();
        }

        private void AddMealTime(MealTime meal)
        {
            this.treeView2.BeginUpdate();
            this.treeView2.ImageList = imageList2;
            int i = treeView2.Nodes.Count;
            this.treeView2.Nodes.Add(meal.Name);
            this.treeView2.Nodes[i].ImageIndex = 0;
            this.treeView2.Nodes[i].ContextMenuStrip = this.contextMenuStrip2;
            this.treeView2.Nodes[i].Tag = meal;
            this.treeView2.EndUpdate();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MealTime meal = new($"Meal Time {treeView2.Nodes.Count + 1}");
            AddMealTime(meal);
            Servise.GetRation().Add(meal);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Servise.GetRation().Remove(this.treeView2.SelectedNode.Tag as MealTime);
            this.treeView2.SelectedNode.Remove();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach(MealTime mealTime in Servise.GetRation())
            {
                if(mealTime == this.treeView2.SelectedNode.Parent.Tag as MealTime)
                {
                    mealTime.GetMealTime.Remove(this.treeView2.SelectedNode.Tag as Product);
                    this.treeView2.SelectedNode.Remove();
                    break;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.treeView2.SelectedNode.BeginEdit();
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.treeView2.SelectedNode = e.Node;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode node)
            {
                if (node != null && node.Tag is Product product)
                {
                    if (sender is TreeView tree)
                    {
                        if (tree == this.treeView2)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                DoDragDrop(e.Item, DragDropEffects.Move);
                            }
                        }
                        else if (e.Button == MouseButtons.Left)
                        {
                            DoDragDrop(e.Item, DragDropEffects.Copy);
                        }
                    }
                }
            }
            
        }

        private void treeView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeView2_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView2.PointToClient(new Point(e.X, e.Y));
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            if (sender is TreeView targetTree)
            {
                Point targetPoint = targetTree.PointToClient(new Point(e.X, e.Y));
                TreeNode? targetNode = targetTree.GetNodeAt(targetPoint);
                TreeNode? draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (targetNode != null && draggedNode != null && targetNode is TreeNode meal && draggedNode.Tag is Product product)
                {
                    AddProductToMeal (meal, product);
                    if (e.Effect == DragDropEffects.Move)
                    {
                        draggedNode.Remove();
                    }

                    targetNode.Expand();
                }
            }
        }

        public void AddProductToMeal (TreeNode mealNode, Product product)
        {
            if (mealNode.Tag is MealTime meal)
            {
                int i = mealNode.Nodes.Count;
                meal.GetMealTime.Add(product);
                mealNode.Nodes.Add(product.Name);
                mealNode.Nodes[i].Tag = product;
                mealNode.Nodes[i].ImageIndex = 1;
                mealNode.Nodes[i].SelectedImageIndex = 1;
                mealNode.Nodes[i].ContextMenuStrip = this.contextMenuStrip3;
            }
        }

    }
}
