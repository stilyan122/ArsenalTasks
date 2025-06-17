namespace MarketVault.UI
{
    partial class OrdersForm
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
            OrdersTitle_Label = new Label();
            BackButton = new Button();
            AddOrder_Button = new Button();
            ShowAllOrders_Button = new Button();
            FilterByCustomer_Button = new Button();
            EmployeeId_Input = new TextBox();
            EmployeeId_Label = new Label();
            AddOrderInput_Button = new Button();
            CustomerId_Input = new TextBox();
            CustomerId_Label = new Label();
            OrderDate_Label = new Label();
            OrderPicker_Input = new DateTimePicker();
            SuspendLayout();
            // 
            // OrdersTitle_Label
            // 
            OrdersTitle_Label.AutoSize = true;
            OrdersTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            OrdersTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrdersTitle_Label.ForeColor = Color.White;
            OrdersTitle_Label.Location = new Point(655, 105);
            OrdersTitle_Label.Name = "OrdersTitle_Label";
            OrdersTitle_Label.Padding = new Padding(25);
            OrdersTitle_Label.Size = new Size(550, 120);
            OrdersTitle_Label.TabIndex = 1;
            OrdersTitle_Label.Text = "📑 Order Manager";
            OrdersTitle_Label.Click += ProjectTitle_Label_Click;
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
            // AddOrder_Button
            // 
            AddOrder_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddOrder_Button.Cursor = Cursors.Hand;
            AddOrder_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddOrder_Button.ForeColor = SystemColors.ControlLightLight;
            AddOrder_Button.Location = new Point(266, 458);
            AddOrder_Button.Name = "AddOrder_Button";
            AddOrder_Button.Size = new Size(308, 72);
            AddOrder_Button.TabIndex = 4;
            AddOrder_Button.Text = "➕ Add Order";
            AddOrder_Button.UseVisualStyleBackColor = false;
            AddOrder_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllOrders_Button
            // 
            ShowAllOrders_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllOrders_Button.Cursor = Cursors.Hand;
            ShowAllOrders_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllOrders_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllOrders_Button.Location = new Point(713, 458);
            ShowAllOrders_Button.Name = "ShowAllOrders_Button";
            ShowAllOrders_Button.Size = new Size(370, 72);
            ShowAllOrders_Button.TabIndex = 5;
            ShowAllOrders_Button.Text = "📋 Show All Orders";
            ShowAllOrders_Button.UseVisualStyleBackColor = false;
            // 
            // FilterByCustomer_Button
            // 
            FilterByCustomer_Button.BackColor = Color.FromArgb(141, 188, 199);
            FilterByCustomer_Button.Cursor = Cursors.Hand;
            FilterByCustomer_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FilterByCustomer_Button.ForeColor = SystemColors.ControlLightLight;
            FilterByCustomer_Button.Location = new Point(1209, 458);
            FilterByCustomer_Button.Name = "FilterByCustomer_Button";
            FilterByCustomer_Button.Size = new Size(417, 72);
            FilterByCustomer_Button.TabIndex = 6;
            FilterByCustomer_Button.Text = "🔍 Filter by Customer";
            FilterByCustomer_Button.UseVisualStyleBackColor = false;
            FilterByCustomer_Button.Click += CategoriesByTotalStock_Button_Click;
            // 
            // EmployeeId_Input
            // 
            EmployeeId_Input.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeId_Input.Location = new Point(264, 510);
            EmployeeId_Input.Name = "EmployeeId_Input";
            EmployeeId_Input.PlaceholderText = "Enter employee id...";
            EmployeeId_Input.Size = new Size(304, 34);
            EmployeeId_Input.TabIndex = 30;
            EmployeeId_Input.Visible = false;
            // 
            // EmployeeId_Label
            // 
            EmployeeId_Label.AutoSize = true;
            EmployeeId_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeId_Label.ForeColor = SystemColors.ControlLightLight;
            EmployeeId_Label.Location = new Point(264, 474);
            EmployeeId_Label.Name = "EmployeeId_Label";
            EmployeeId_Label.Size = new Size(243, 33);
            EmployeeId_Label.TabIndex = 29;
            EmployeeId_Label.Text = "Order Employee Id";
            EmployeeId_Label.Visible = false;
            // 
            // AddOrderInput_Button
            // 
            AddOrderInput_Button.BackColor = Color.FromArgb(196, 225, 230);
            AddOrderInput_Button.Cursor = Cursors.Hand;
            AddOrderInput_Button.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddOrderInput_Button.ForeColor = SystemColors.ControlLightLight;
            AddOrderInput_Button.Location = new Point(263, 584);
            AddOrderInput_Button.Name = "AddOrderInput_Button";
            AddOrderInput_Button.Size = new Size(305, 52);
            AddOrderInput_Button.TabIndex = 28;
            AddOrderInput_Button.Text = "➕ Add Order";
            AddOrderInput_Button.UseVisualStyleBackColor = false;
            AddOrderInput_Button.Visible = false;
            AddOrderInput_Button.Click += AddOrderInput_Button_Click;
            // 
            // CustomerId_Input
            // 
            CustomerId_Input.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerId_Input.Location = new Point(266, 417);
            CustomerId_Input.Name = "CustomerId_Input";
            CustomerId_Input.PlaceholderText = "Enter customer id...";
            CustomerId_Input.Size = new Size(304, 34);
            CustomerId_Input.TabIndex = 27;
            CustomerId_Input.Visible = false;
            // 
            // CustomerId_Label
            // 
            CustomerId_Label.AutoSize = true;
            CustomerId_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerId_Label.ForeColor = SystemColors.ControlLightLight;
            CustomerId_Label.Location = new Point(263, 381);
            CustomerId_Label.Name = "CustomerId_Label";
            CustomerId_Label.Size = new Size(240, 33);
            CustomerId_Label.TabIndex = 26;
            CustomerId_Label.Text = "Order Customer Id";
            CustomerId_Label.Visible = false;
            // 
            // OrderDate_Label
            // 
            OrderDate_Label.AutoSize = true;
            OrderDate_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderDate_Label.ForeColor = SystemColors.ControlLightLight;
            OrderDate_Label.Location = new Point(264, 296);
            OrderDate_Label.Name = "OrderDate_Label";
            OrderDate_Label.Size = new Size(149, 33);
            OrderDate_Label.TabIndex = 24;
            OrderDate_Label.Text = "Order Date";
            OrderDate_Label.Visible = false;
            // 
            // OrderPicker_Input
            // 
            OrderPicker_Input.CalendarFont = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OrderPicker_Input.Location = new Point(266, 332);
            OrderPicker_Input.Name = "OrderPicker_Input";
            OrderPicker_Input.Size = new Size(250, 27);
            OrderPicker_Input.TabIndex = 31;
            OrderPicker_Input.Visible = false;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(OrderPicker_Input);
            Controls.Add(EmployeeId_Input);
            Controls.Add(EmployeeId_Label);
            Controls.Add(AddOrderInput_Button);
            Controls.Add(CustomerId_Input);
            Controls.Add(CustomerId_Label);
            Controls.Add(OrderDate_Label);
            Controls.Add(FilterByCustomer_Button);
            Controls.Add(ShowAllOrders_Button);
            Controls.Add(AddOrder_Button);
            Controls.Add(BackButton);
            Controls.Add(OrdersTitle_Label);
            Name = "OrdersForm";
            Text = "CategoriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OrdersTitle_Label;
        private Button BackButton;
        private Button AddOrder_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllOrders_Button;
        private Button FilterByCustomer_Button;
        private TextBox EmployeeId_Input;
        private Label EmployeeId_Label;
        private Button AddOrderInput_Button;
        private TextBox CustomerId_Input;
        private Label CustomerId_Label;
        private TextBox EmployeeName_Input;
        private Label OrderDate_Label;
        private DateTimePicker OrderPicker_Input;
        private Button AddEmployee_Button;
    }
}