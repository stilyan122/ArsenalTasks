namespace MarketVault.UI
{
    partial class CustomersForm
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
            CustomersTitle_Label = new Label();
            BackButton = new Button();
            AddCustomer_Button = new Button();
            ShowAllCustomers_Button = new Button();
            CustomersWithNoOrders_Button = new Button();
            SuspendLayout();
            // 
            // CustomersTitle_Label
            // 
            CustomersTitle_Label.AutoSize = true;
            CustomersTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            CustomersTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomersTitle_Label.ForeColor = Color.White;
            CustomersTitle_Label.Location = new Point(655, 105);
            CustomersTitle_Label.Name = "CustomersTitle_Label";
            CustomersTitle_Label.Padding = new Padding(25);
            CustomersTitle_Label.Size = new Size(648, 120);
            CustomersTitle_Label.TabIndex = 1;
            CustomersTitle_Label.Text = "👥 Customer Manager";
            CustomersTitle_Label.Click += ProjectTitle_Label_Click;
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
            // AddCustomer_Button
            // 
            AddCustomer_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddCustomer_Button.Cursor = Cursors.Hand;
            AddCustomer_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddCustomer_Button.ForeColor = SystemColors.ControlLightLight;
            AddCustomer_Button.Location = new Point(266, 458);
            AddCustomer_Button.Name = "AddCustomer_Button";
            AddCustomer_Button.Size = new Size(308, 72);
            AddCustomer_Button.TabIndex = 4;
            AddCustomer_Button.Text = "➕ Add Customer";
            AddCustomer_Button.UseVisualStyleBackColor = false;
            AddCustomer_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllCustomers_Button
            // 
            ShowAllCustomers_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllCustomers_Button.Cursor = Cursors.Hand;
            ShowAllCustomers_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllCustomers_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllCustomers_Button.Location = new Point(713, 458);
            ShowAllCustomers_Button.Name = "ShowAllCustomers_Button";
            ShowAllCustomers_Button.Size = new Size(370, 72);
            ShowAllCustomers_Button.TabIndex = 5;
            ShowAllCustomers_Button.Text = "📋 Show All Customers";
            ShowAllCustomers_Button.UseVisualStyleBackColor = false;
            // 
            // CustomersWithNoOrders_Button
            // 
            CustomersWithNoOrders_Button.BackColor = Color.FromArgb(141, 188, 199);
            CustomersWithNoOrders_Button.Cursor = Cursors.Hand;
            CustomersWithNoOrders_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CustomersWithNoOrders_Button.ForeColor = SystemColors.ControlLightLight;
            CustomersWithNoOrders_Button.Location = new Point(1209, 458);
            CustomersWithNoOrders_Button.Name = "CustomersWithNoOrders_Button";
            CustomersWithNoOrders_Button.Size = new Size(417, 72);
            CustomersWithNoOrders_Button.TabIndex = 6;
            CustomersWithNoOrders_Button.Text = "📊 Customers With No Orders";
            CustomersWithNoOrders_Button.UseVisualStyleBackColor = false;
            CustomersWithNoOrders_Button.Click += CategoriesByTotalStock_Button_Click;
            // 
            // CustomersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(CustomersWithNoOrders_Button);
            Controls.Add(ShowAllCustomers_Button);
            Controls.Add(AddCustomer_Button);
            Controls.Add(BackButton);
            Controls.Add(CustomersTitle_Label);
            Name = "CustomersForm";
            Text = "CategoriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomersTitle_Label;
        private Button BackButton;
        private Button AddCustomer_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllCustomers_Button;
        private Button CustomersWithNoOrders_Button;
    }
}