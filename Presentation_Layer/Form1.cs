﻿#nullable enable
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
            Servise.SetPath(@"D:\The_3_semestr\Daily Meal Planner\Data_Layer\bin\Debug\net5.0\FoodProducts.xml");
            int i = 0;
            string message = string.Empty;
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
                    if (product.Validate(ref message))
                    {
                        this.treeView1.Nodes[i].Nodes.Add(product.Name);
                        this.treeView1.Nodes[i].Nodes[j].ImageIndex = i;
                        this.treeView1.Nodes[i].Nodes[j].SelectedImageIndex = 25;
                        this.treeView1.Nodes[i].Nodes[j].Tag = product;
                        j++;
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                }

                i++;
            }

            this.treeView1.EndUpdate();
        }

        private void FillTreeViewRation()
        {
            string message = string.Empty;
            this.treeView2.BeginUpdate();
            this.treeView2.Nodes.Clear();
            this.treeView2.ImageList = imageList2;
            foreach (MealTime meal in Servise.GetRation())
            {
                if (meal.Validate(ref message))
                {
                    AddMealTime(meal);
                }
                else
                {
                    MessageBox.Show(message);
                }
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
            this.progressBar2.Value = (int)Servise.GetCalories();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach(MealTime mealTime in Servise.GetRation())
            {
                if (mealTime == this.treeView2.SelectedNode.Parent.Tag as MealTime)
                {
                    mealTime.GetMealTime.Remove(this.treeView2.SelectedNode.Tag as Product);
                    this.treeView2.SelectedNode.Remove();
                    this.progressBar2.Value = (int)Servise.GetCalories();
                    break;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.treeView2.SelectedNode.BeginEdit();
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
            treeView1.SelectedNode = treeView2.GetNodeAt(targetPoint);
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
                    if (e.Effect == DragDropEffects.Move)
                    {
                       (draggedNode.Parent.Tag as MealTime).DelProduct(product);
                       draggedNode.Remove();
                    }

                    Product mealProduct = new Product(product);
                    AddProductToMeal (meal, mealProduct);
                    targetNode.Expand();
                }
            }
        }

        public void AddProductToMeal (TreeNode mealNode, Product product)
        {
            if (mealNode.Tag is MealTime meal)
            {
                Product prbuff = product;
                prbuff.Gramms = trackBar1.Value;
                if (Servise.GetCalories() - product.Calories + prbuff.Calories < this.progressBar2.Maximum)
                {
                    int i = mealNode.Nodes.Count;
                    meal.GetMealTime.Add(product);
                    mealNode.Nodes.Add(product.Name);
                    mealNode.Nodes[i].Tag = product;
                    mealNode.Nodes[i].ImageIndex = 1;
                    mealNode.Nodes[i].SelectedImageIndex = 1;
                    mealNode.Nodes[i].ContextMenuStrip = this.contextMenuStrip3;
                    this.textBox12.Text = Convert.ToString(Math.Round((double)Servise.GetCalories(), 2));
                    this.progressBar2.Value = (int)Servise.GetCalories();
                }
                else
                {
                    trackBar1.Value = product.Gramms;
                    MessageBox.Show("Current caloriec can't be more then 6000 kcal!");
                }
            }
        }

        public List<TreeNode> SearchNodes(string searchText, TreeNode startNode)
        {
            List<TreeNode> currentNode = new();
            while (startNode != null)
            {
                if (startNode.Text.ToLower().Contains(searchText.ToLower()))
                {

                    currentNode.Add(startNode);
                }

                if (startNode.Nodes.Count != 0)
                {
                    foreach (TreeNode node in SearchNodes(searchText, startNode.Nodes[0]))
                    {
                        currentNode.Add(node);
                    }        
                }

                startNode = startNode.NextNode;
            }
            
            return currentNode;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = this.textBox1.Text;
            string lastSearchText = string.Empty;
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                node.BackColor = Color.Transparent;
                node.Collapse();
                foreach (TreeNode node2 in node.Nodes)
                {
                    node2.BackColor = Color.Transparent;
                }
            }

            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            if (lastSearchText != searchText)
            {
                lastSearchText = searchText;
                foreach (TreeNode node in SearchNodes(lastSearchText, this.treeView1.Nodes[0]))
                {
                    node.BackColor = Color.LightGreen;
                    if (node.Parent != null)
                    {
                        node.Parent.Expand();
                    }

                }
            } 
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty)
            {
                Servise.SetUserWeight(Convert.ToDouble(this.textBox2.Text));
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                Servise.SetUserHeight(Convert.ToDouble(this.textBox3.Text));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                Servise.SetUserAge(Convert.ToInt32(this.textBox4.Text));
            }   
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DailyChangeIfEmpty();
            Servise.SetUserActivity(1.2);
            DailyRateChange();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DailyChangeIfEmpty();
            Servise.SetUserActivity(1.375);
            DailyRateChange();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DailyChangeIfEmpty();
            Servise.SetUserActivity(1.55);
            DailyRateChange();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DailyChangeIfEmpty();
            Servise.SetUserActivity(1.725);
            DailyRateChange();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string massege = string.Empty;
            if (Servise.UserValidate(ref massege))
            {
                this.textBox5.Text = Convert.ToString(Servise.GetDailyRate());
                this.textBox11.Text = Convert.ToString(Servise.GetDailyRate());
                this.progressBar1.Value = Servise.GetDailyRate();
            }
            else
            {
                MessageBox.Show(massege);
            }
        }

        private void DailyRateChange ()
        {
            if (this.textBox2.Text != string.Empty && this.textBox3.Text != string.Empty && this.textBox4.Text != string.Empty)
            {
                textBox5_TextChanged(this.textBox5, new EventArgs());
            }
            
        }

        private void DailyChangeIfEmpty ()
        {
            if (this.textBox2.Text == string.Empty || this.textBox3.Text == string.Empty || this.textBox4.Text == string.Empty)
            {
                Servise.SetUserActivity(0.0);
                this.textBox5.Text = Convert.ToString(Servise.GetDailyRate());
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            DailyRateChange();
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (sender is TreeView tree)
            {
                if (tree == treeView1)
                {
                    this.trackBar1.Enabled = false;
                    if (e.Node.Tag is Product product)
                    {
                        ProductInfoChange(product);
                        this.trackBar1.Value = product.Gramms;
                    }
                }
                else if (tree == treeView2)
                {
                    this.trackBar1.Enabled = true;
                    if (e.Node.Tag is Product product)
                    {
                        this.trackBar1.Enabled = true;
                        ProductInfoChange(product);
                        this.trackBar1.Value = product.Gramms;
                    }
                    else
                    {
                        this.trackBar1.Enabled = false;
                    }
                }

                tree.SelectedNode = e.Node;
            }  
        }

        private void ProductInfoChange(Product product)
        {
            this.textBox6.Text = Convert.ToString(Math.Round((double)product.Gramms, 2));
            this.textBox7.Text = Convert.ToString(Math.Round((double)product.Calories, 2));
            this.textBox8.Text = Convert.ToString(Math.Round((double)product.Protein, 2));
            this.textBox9.Text = Convert.ToString(Math.Round((double)product.Fats, 2));
            this.textBox10.Text = Convert.ToString(Math.Round((double)product.Carbs, 2));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (this.treeView2.SelectedNode.Tag is Product product)
            {
                Product prbuff = product;
                prbuff.Gramms = trackBar1.Value;
                if (Servise.GetCalories() - product.Calories + prbuff.Calories < this.progressBar2.Maximum)
                {
                    product.Gramms = trackBar1.Value;
                    this.textBox12.Text = Convert.ToString(Math.Round((double)Servise.GetCalories(), 2));
                    this.progressBar2.Value = (int)Servise.GetCalories();
                    ProductInfoChange(product);
                }
                else
                {
                    trackBar1.Value = product.Gramms;
                    MessageBox.Show("Current caloriec can't be more then 6000 kcal!");
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != string.Empty && this.textBox3.Text != string.Empty && this.textBox4.Text != string.Empty && 
                (this.radioButton1.Checked != false || this.radioButton2.Checked != false || this.radioButton3.Checked != false || this.radioButton4.Checked != false))
            {
                Servise.SaveToPdf();
            }
            else
            {
                MessageBox.Show("User Parameters and Activity must be filled!");
            }
                
        }
    }
}
