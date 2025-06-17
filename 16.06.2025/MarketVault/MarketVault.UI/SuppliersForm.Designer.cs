namespace MarketVault.UI
{
    partial class SuppliersForm
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
            SuppliersTitle_Label = new Label();
            BackButton = new Button();
            AddSupplier_Button = new Button();
            ShowAllSuppliers_Button = new Button();
            SuppliersByProduct_Button = new Button();
            SuspendLayout();
            // 
            // SuppliersTitle_Label
            // 
            SuppliersTitle_Label.AutoSize = true;
            SuppliersTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            SuppliersTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SuppliersTitle_Label.ForeColor = Color.White;
            SuppliersTitle_Label.Location = new Point(655, 105);
            SuppliersTitle_Label.Name = "SuppliersTitle_Label";
            SuppliersTitle_Label.Padding = new Padding(25);
            SuppliersTitle_Label.Size = new Size(616, 120);
            SuppliersTitle_Label.TabIndex = 1;
            SuppliersTitle_Label.Text = "🚚 Supplier Manager";
            SuppliersTitle_Label.Click += ProjectTitle_Label_Click;
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
            // AddSupplier_Button
            // 
            AddSupplier_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddSupplier_Button.Cursor = Cursors.Hand;
            AddSupplier_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddSupplier_Button.ForeColor = SystemColors.ControlLightLight;
            AddSupplier_Button.Location = new Point(266, 458);
            AddSupplier_Button.Name = "AddSupplier_Button";
            AddSupplier_Button.Size = new Size(308, 72);
            AddSupplier_Button.TabIndex = 4;
            AddSupplier_Button.Text = "➕ Add Supplier";
            AddSupplier_Button.UseVisualStyleBackColor = false;
            AddSupplier_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllSuppliers_Button
            // 
            ShowAllSuppliers_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllSuppliers_Button.Cursor = Cursors.Hand;
            ShowAllSuppliers_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllSuppliers_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllSuppliers_Button.Location = new Point(713, 458);
            ShowAllSuppliers_Button.Name = "ShowAllSuppliers_Button";
            ShowAllSuppliers_Button.Size = new Size(370, 72);
            ShowAllSuppliers_Button.TabIndex = 5;
            ShowAllSuppliers_Button.Text = "📋 Show All Suppliers";
            ShowAllSuppliers_Button.UseVisualStyleBackColor = false;
            // 
            // SuppliersByProduct_Button
            // 
            SuppliersByProduct_Button.BackColor = Color.FromArgb(141, 188, 199);
            SuppliersByProduct_Button.Cursor = Cursors.Hand;
            SuppliersByProduct_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SuppliersByProduct_Button.ForeColor = SystemColors.ControlLightLight;
            SuppliersByProduct_Button.Location = new Point(1201, 458);
            SuppliersByProduct_Button.Name = "SuppliersByProduct_Button";
            SuppliersByProduct_Button.Size = new Size(414, 72);
            SuppliersByProduct_Button.TabIndex = 6;
            SuppliersByProduct_Button.Text = "📦 Show Suppliers by Product";
            SuppliersByProduct_Button.UseVisualStyleBackColor = false;
            SuppliersByProduct_Button.Click += CategoriesByTotalStock_Button_Click;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(SuppliersByProduct_Button);
            Controls.Add(ShowAllSuppliers_Button);
            Controls.Add(AddSupplier_Button);
            Controls.Add(BackButton);
            Controls.Add(SuppliersTitle_Label);
            Name = "SuppliersForm";
            Text = "CategoriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SuppliersTitle_Label;
        private Button BackButton;
        private Button AddSupplier_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllSuppliers_Button;
        private Button SuppliersByProduct_Button;   
    }
}