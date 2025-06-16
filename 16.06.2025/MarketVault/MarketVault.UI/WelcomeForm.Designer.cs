namespace MarketVault.UI
{
    partial class WelcomeForm
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
            ProjectTitle_Label = new Label();
            ManageMarketVault_Button = new Button();
            ManageCategories_Button = new Button();
            ManageProducts_Button = new Button();
            ManageEmployees_Button = new Button();
            ManageSuppliers_Button = new Button();
            ManageCustomers_Button = new Button();
            ManageOrders_Button = new Button();
            SuspendLayout();
            // 
            // ProjectTitle_Label
            // 
            ProjectTitle_Label.AutoSize = true;
            ProjectTitle_Label.BackColor = Color.FromArgb(141, 188, 199);
            ProjectTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectTitle_Label.Location = new Point(597, 154);
            ProjectTitle_Label.Name = "ProjectTitle_Label";
            ProjectTitle_Label.Padding = new Padding(25);
            ProjectTitle_Label.Size = new Size(702, 120);
            ProjectTitle_Label.TabIndex = 0;
            ProjectTitle_Label.Text = "Welcome to MarketVault";
            ProjectTitle_Label.Click += label1_Click;
            // 
            // ManageMarketVault_Button
            // 
            ManageMarketVault_Button.BackColor = Color.FromArgb(235, 255, 216);
            ManageMarketVault_Button.Cursor = Cursors.Hand;
            ManageMarketVault_Button.Font = new Font("Cambria", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ManageMarketVault_Button.ForeColor = Color.Black;
            ManageMarketVault_Button.Location = new Point(734, 390);
            ManageMarketVault_Button.Name = "ManageMarketVault_Button";
            ManageMarketVault_Button.Size = new Size(417, 95);
            ManageMarketVault_Button.TabIndex = 1;
            ManageMarketVault_Button.Text = "⚙️ Manage MarketVault";
            ManageMarketVault_Button.UseVisualStyleBackColor = false;
            ManageMarketVault_Button.Click += button1_Click;
            // 
            // ManageCategories_Button
            // 
            ManageCategories_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageCategories_Button.Cursor = Cursors.Hand;
            ManageCategories_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageCategories_Button.Location = new Point(120, 413);
            ManageCategories_Button.Name = "ManageCategories_Button";
            ManageCategories_Button.Size = new Size(308, 72);
            ManageCategories_Button.TabIndex = 3;
            ManageCategories_Button.Text = "📁 Manage Categories";
            ManageCategories_Button.UseVisualStyleBackColor = false;
            ManageCategories_Button.Visible = false;
            ManageCategories_Button.Click += ManagaCategories_Button_Click;
            // 
            // ManageProducts_Button
            // 
            ManageProducts_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageProducts_Button.Cursor = Cursors.Hand;
            ManageProducts_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageProducts_Button.Location = new Point(268, 593);
            ManageProducts_Button.Name = "ManageProducts_Button";
            ManageProducts_Button.Size = new Size(315, 72);
            ManageProducts_Button.TabIndex = 8;
            ManageProducts_Button.Text = "📦 Manage Products";
            ManageProducts_Button.UseVisualStyleBackColor = false;
            ManageProducts_Button.Visible = false;
            ManageProducts_Button.Click += ManageProducts_Button_Click;
            // 
            // ManageEmployees_Button
            // 
            ManageEmployees_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageEmployees_Button.Cursor = Cursors.Hand;
            ManageEmployees_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageEmployees_Button.Location = new Point(1480, 413);
            ManageEmployees_Button.Name = "ManageEmployees_Button";
            ManageEmployees_Button.Size = new Size(315, 72);
            ManageEmployees_Button.TabIndex = 9;
            ManageEmployees_Button.Text = "👨‍💼 Manage Employees";
            ManageEmployees_Button.UseVisualStyleBackColor = false;
            ManageEmployees_Button.Visible = false;
            // 
            // ManageSuppliers_Button
            // 
            ManageSuppliers_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageSuppliers_Button.Cursor = Cursors.Hand;
            ManageSuppliers_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageSuppliers_Button.Location = new Point(1295, 593);
            ManageSuppliers_Button.Name = "ManageSuppliers_Button";
            ManageSuppliers_Button.Size = new Size(315, 72);
            ManageSuppliers_Button.TabIndex = 10;
            ManageSuppliers_Button.Text = "🚚 Manage Suppliers";
            ManageSuppliers_Button.UseVisualStyleBackColor = false;
            ManageSuppliers_Button.Visible = false;
            ManageSuppliers_Button.Click += ManageSuppliers_Button_Click;
            // 
            // ManageCustomers_Button
            // 
            ManageCustomers_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageCustomers_Button.Cursor = Cursors.Hand;
            ManageCustomers_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageCustomers_Button.Location = new Point(1059, 757);
            ManageCustomers_Button.Name = "ManageCustomers_Button";
            ManageCustomers_Button.Size = new Size(315, 72);
            ManageCustomers_Button.TabIndex = 11;
            ManageCustomers_Button.Text = "\U0001f9cd Manage Customers";
            ManageCustomers_Button.UseVisualStyleBackColor = false;
            ManageCustomers_Button.Visible = false;
            ManageCustomers_Button.Click += ManageCustomers_Button_Click;
            // 
            // ManageOrders_Button
            // 
            ManageOrders_Button.BackColor = Color.FromArgb(141, 188, 199);
            ManageOrders_Button.Cursor = Cursors.Hand;
            ManageOrders_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ManageOrders_Button.Location = new Point(597, 757);
            ManageOrders_Button.Name = "ManageOrders_Button";
            ManageOrders_Button.Size = new Size(315, 72);
            ManageOrders_Button.TabIndex = 12;
            ManageOrders_Button.Text = "📑 Manage Orders";
            ManageOrders_Button.UseVisualStyleBackColor = false;
            ManageOrders_Button.Visible = false;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(196, 225, 230);
            ClientSize = new Size(1920, 1055);
            Controls.Add(ManageOrders_Button);
            Controls.Add(ManageCustomers_Button);
            Controls.Add(ManageSuppliers_Button);
            Controls.Add(ManageEmployees_Button);
            Controls.Add(ManageProducts_Button);
            Controls.Add(ManageCategories_Button);
            Controls.Add(ManageMarketVault_Button);
            Controls.Add(ProjectTitle_Label);
            ForeColor = Color.White;
            Name = "WelcomeForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProjectTitle_Label;
        private Button ManageMarketVault_Button;
        private Button ManageCategories_Button;
        private Button ManageProducts_Button;
        private Button ManageEmployees_Button;
        private Button ManageSuppliers_Button;
        private Button ManageCustomers_Button;
        private Button ManageOrders_Button;
    }
}
