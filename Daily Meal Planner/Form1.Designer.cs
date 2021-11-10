
namespace Daily_Meal_Planner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(298, 58);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(313, 472);
            this.treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(716, 58);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(313, 472);
            this.treeView2.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cocktail.png");
            this.imageList1.Images.SetKeyName(1, "fast-food.png");
            this.imageList1.Images.SetKeyName(2, "mushrooms.png");
            this.imageList1.Images.SetKeyName(3, "porridge.png");
            this.imageList1.Images.SetKeyName(4, "salami.png");
            this.imageList1.Images.SetKeyName(5, "compote.png");
            this.imageList1.Images.SetKeyName(6, "butter.png");
            this.imageList1.Images.SetKeyName(7, "milk.png");
            this.imageList1.Images.SetKeyName(8, "carrot.png");
            this.imageList1.Images.SetKeyName(9, "flour.png");
            this.imageList1.Images.SetKeyName(10, "meat.png");
            this.imageList1.Images.SetKeyName(11, "vegetables.png");
            this.imageList1.Images.SetKeyName(12, "nuts.png");
            this.imageList1.Images.SetKeyName(13, "procee.png");
            this.imageList1.Images.SetKeyName(14, "fish.png");
            this.imageList1.Images.SetKeyName(15, "cupcake.png");
            this.imageList1.Images.SetKeyName(16, "juice.png");
            this.imageList1.Images.SetKeyName(17, "soup.png");
            this.imageList1.Images.SetKeyName(18, "dried-fruit.png");
            this.imageList1.Images.SetKeyName(19, "cheese.png");
            this.imageList1.Images.SetKeyName(20, "tvorog.png");
            this.imageList1.Images.SetKeyName(21, "fruits.png");
            this.imageList1.Images.SetKeyName(22, "bread.png");
            this.imageList1.Images.SetKeyName(23, "berry.png");
            this.imageList1.Images.SetKeyName(24, "eggs.png");
            this.imageList1.Images.SetKeyName(25, "check.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 633);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Meal Planer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ImageList imageList1;
    }
}

