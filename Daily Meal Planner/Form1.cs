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
    }
}
