namespace MarketVault.UI
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductsTitle_Label = new Label();
            BackButton = new Button();
            AddProduct_Button = new Button();
            ShowAllProducts_Button = new Button();
            NeverOrderedProducts_Button = new Button();
            SuspendLayout();
            // 
            // ProductsTitle_Label
            // 
            ProductsTitle_Label.AutoSize = true;
            ProductsTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            ProductsTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductsTitle_Label.ForeColor = Color.White;
            ProductsTitle_Label.Location = new Point(655, 105);
            ProductsTitle_Label.Name = "ProductsTitle_Label";
            ProductsTitle_Label.Padding = new Padding(25);
            ProductsTitle_Label.Size = new Size(602, 120);
            ProductsTitle_Label.TabIndex = 1;
            ProductsTitle_Label.Text = "📦 Product Manager";
            ProductsTitle_Label.Click += ProjectTitle_Label_Click;
            // 
            // BackButton
            // 
            BackButton.BackColor = Color.FromArgb(235, 255, 216);
            BackButton.Cursor = Cursors.Hand;
            BackButton.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackButton.Location = new Point(90, 791);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(306, 91);
            BackButton.TabIndex = 2;
            BackButton.Text = "🔙 Back to Main Menu";
            BackButton.UseVisualStyleBackColor = false;
            BackButton.Click += BackButton_Click;
            // 
            // AddProduct_Button
            // 
            AddProduct_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddProduct_Button.Cursor = Cursors.Hand;
            AddProduct_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddProduct_Button.ForeColor = SystemColors.ControlLightLight;
            AddProduct_Button.Location = new Point(266, 458);
            AddProduct_Button.Name = "AddProduct_Button";
            AddProduct_Button.Size = new Size(308, 72);
            AddProduct_Button.TabIndex = 4;
            AddProduct_Button.Text = "➕ Add Product";
            AddProduct_Button.UseVisualStyleBackColor = false;
            AddProduct_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllProducts_Button
            // 
            ShowAllProducts_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllProducts_Button.Cursor = Cursors.Hand;
            ShowAllProducts_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllProducts_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllProducts_Button.Location = new Point(713, 458);
            ShowAllProducts_Button.Name = "ShowAllProducts_Button";
            ShowAllProducts_Button.Size = new Size(370, 72);
            ShowAllProducts_Button.TabIndex = 5;
            ShowAllProducts_Button.Text = "📋 Show All Products";
            ShowAllProducts_Button.UseVisualStyleBackColor = false;
            // 
            // NeverOrderedProducts_Button
            // 
            NeverOrderedProducts_Button.BackColor = Color.FromArgb(141, 188, 199);
            NeverOrderedProducts_Button.Cursor = Cursors.Hand;
            NeverOrderedProducts_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NeverOrderedProducts_Button.ForeColor = SystemColors.ControlLightLight;
            NeverOrderedProducts_Button.Location = new Point(1209, 458);
            NeverOrderedProducts_Button.Name = "NeverOrderedProducts_Button";
            NeverOrderedProducts_Button.Size = new Size(389, 72);
            NeverOrderedProducts_Button.TabIndex = 6;
            NeverOrderedProducts_Button.Text = "📊 Never-ordered products";
            NeverOrderedProducts_Button.UseVisualStyleBackColor = false;
            NeverOrderedProducts_Button.Click += CategoriesByTotalStock_Button_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(NeverOrderedProducts_Button);
            Controls.Add(ShowAllProducts_Button);
            Controls.Add(AddProduct_Button);
            Controls.Add(BackButton);
            Controls.Add(ProductsTitle_Label);
            Name = "ProductsForm";
            Text = "CategoriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductsTitle_Label;
        private Button BackButton;
        private Button AddProduct_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllProducts_Button;
        private Button NeverOrderedProducts_Button;
    }
}