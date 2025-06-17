namespace MarketVault.UI
{
    partial class EmployeesForm
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
            EmployeesTitle_Label = new Label();
            BackButton = new Button();
            AddEmployee_Button = new Button();
            ShowAllEmployees_Button = new Button();
            SearchByEmployeeName_Button = new Button();
            AddEmployeeInput_Button = new Button();
            EmployeePosition_Input = new TextBox();
            EmployeePosition_Label = new Label();
            EmployeeName_Input = new TextBox();
            EmployeeName_Label = new Label();
            EmployeeSalary_Label = new Label();
            EmployeeSalaryInput = new TextBox();
            SuspendLayout();
            // 
            // EmployeesTitle_Label
            // 
            EmployeesTitle_Label.AutoSize = true;
            EmployeesTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            EmployeesTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeesTitle_Label.ForeColor = Color.White;
            EmployeesTitle_Label.Location = new Point(655, 105);
            EmployeesTitle_Label.Name = "EmployeesTitle_Label";
            EmployeesTitle_Label.Padding = new Padding(25);
            EmployeesTitle_Label.Size = new Size(652, 120);
            EmployeesTitle_Label.TabIndex = 1;
            EmployeesTitle_Label.Text = "👤 Employee Manager";
            EmployeesTitle_Label.Click += ProjectTitle_Label_Click;
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
            // AddEmployee_Button
            // 
            AddEmployee_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddEmployee_Button.Cursor = Cursors.Hand;
            AddEmployee_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddEmployee_Button.ForeColor = SystemColors.ControlLightLight;
            AddEmployee_Button.Location = new Point(266, 458);
            AddEmployee_Button.Name = "AddEmployee_Button";
            AddEmployee_Button.Size = new Size(308, 72);
            AddEmployee_Button.TabIndex = 4;
            AddEmployee_Button.Text = "➕ Add Employee";
            AddEmployee_Button.UseVisualStyleBackColor = false;
            AddEmployee_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllEmployees_Button
            // 
            ShowAllEmployees_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllEmployees_Button.Cursor = Cursors.Hand;
            ShowAllEmployees_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllEmployees_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllEmployees_Button.Location = new Point(713, 458);
            ShowAllEmployees_Button.Name = "ShowAllEmployees_Button";
            ShowAllEmployees_Button.Size = new Size(370, 72);
            ShowAllEmployees_Button.TabIndex = 5;
            ShowAllEmployees_Button.Text = "📋 Show All Employees";
            ShowAllEmployees_Button.UseVisualStyleBackColor = false;
            // 
            // SearchByEmployeeName_Button
            // 
            SearchByEmployeeName_Button.BackColor = Color.FromArgb(141, 188, 199);
            SearchByEmployeeName_Button.Cursor = Cursors.Hand;
            SearchByEmployeeName_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchByEmployeeName_Button.ForeColor = SystemColors.ControlLightLight;
            SearchByEmployeeName_Button.Location = new Point(1209, 458);
            SearchByEmployeeName_Button.Name = "SearchByEmployeeName_Button";
            SearchByEmployeeName_Button.Size = new Size(407, 72);
            SearchByEmployeeName_Button.TabIndex = 6;
            SearchByEmployeeName_Button.Text = "🔍 Search by Employee Name";
            SearchByEmployeeName_Button.UseVisualStyleBackColor = false;
            SearchByEmployeeName_Button.Click += CategoriesByTotalStock_Button_Click;
            // 
            // AddEmployeeInput_Button
            // 
            AddEmployeeInput_Button.BackColor = Color.FromArgb(196, 225, 230);
            AddEmployeeInput_Button.Cursor = Cursors.Hand;
            AddEmployeeInput_Button.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddEmployeeInput_Button.ForeColor = SystemColors.ControlLightLight;
            AddEmployeeInput_Button.Location = new Point(263, 558);
            AddEmployeeInput_Button.Name = "AddEmployeeInput_Button";
            AddEmployeeInput_Button.Size = new Size(305, 52);
            AddEmployeeInput_Button.TabIndex = 20;
            AddEmployeeInput_Button.Text = "➕ Add Employee";
            AddEmployeeInput_Button.UseVisualStyleBackColor = false;
            AddEmployeeInput_Button.Visible = false;
            AddEmployeeInput_Button.Click += AddEmployeeInput_Button_Click;
            // 
            // EmployeePosition_Input
            // 
            EmployeePosition_Input.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeePosition_Input.Location = new Point(266, 391);
            EmployeePosition_Input.Name = "EmployeePosition_Input";
            EmployeePosition_Input.PlaceholderText = "Enter employee position...";
            EmployeePosition_Input.Size = new Size(304, 34);
            EmployeePosition_Input.TabIndex = 19;
            EmployeePosition_Input.Visible = false;
            // 
            // EmployeePosition_Label
            // 
            EmployeePosition_Label.AutoSize = true;
            EmployeePosition_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeePosition_Label.ForeColor = SystemColors.ControlLightLight;
            EmployeePosition_Label.Location = new Point(263, 355);
            EmployeePosition_Label.Name = "EmployeePosition_Label";
            EmployeePosition_Label.Size = new Size(238, 33);
            EmployeePosition_Label.TabIndex = 18;
            EmployeePosition_Label.Text = "Employee Position";
            EmployeePosition_Label.Visible = false;
            // 
            // EmployeeName_Input
            // 
            EmployeeName_Input.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeName_Input.Location = new Point(267, 305);
            EmployeeName_Input.Name = "EmployeeName_Input";
            EmployeeName_Input.PlaceholderText = "Enter employee name...";
            EmployeeName_Input.Size = new Size(304, 34);
            EmployeeName_Input.TabIndex = 17;
            EmployeeName_Input.Visible = false;
            // 
            // EmployeeName_Label
            // 
            EmployeeName_Label.AutoSize = true;
            EmployeeName_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeName_Label.ForeColor = SystemColors.ControlLightLight;
            EmployeeName_Label.Location = new Point(266, 259);
            EmployeeName_Label.Name = "EmployeeName_Label";
            EmployeeName_Label.Size = new Size(210, 33);
            EmployeeName_Label.TabIndex = 16;
            EmployeeName_Label.Text = "Employee Name";
            EmployeeName_Label.Visible = false;
            // 
            // EmployeeSalary_Label
            // 
            EmployeeSalary_Label.AutoSize = true;
            EmployeeSalary_Label.Font = new Font("Cambria", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeSalary_Label.ForeColor = SystemColors.ControlLightLight;
            EmployeeSalary_Label.Location = new Point(263, 448);
            EmployeeSalary_Label.Name = "EmployeeSalary_Label";
            EmployeeSalary_Label.Size = new Size(216, 33);
            EmployeeSalary_Label.TabIndex = 21;
            EmployeeSalary_Label.Text = "Employee Salary";
            EmployeeSalary_Label.Visible = false;
            // 
            // EmployeeSalaryInput
            // 
            EmployeeSalaryInput.Font = new Font("Cambria", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmployeeSalaryInput.Location = new Point(266, 484);
            EmployeeSalaryInput.Name = "EmployeeSalaryInput";
            EmployeeSalaryInput.PlaceholderText = "Enter employee salary...";
            EmployeeSalaryInput.Size = new Size(304, 34);
            EmployeeSalaryInput.TabIndex = 22;
            EmployeeSalaryInput.Visible = false;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(EmployeeSalaryInput);
            Controls.Add(EmployeeSalary_Label);
            Controls.Add(AddEmployeeInput_Button);
            Controls.Add(EmployeePosition_Input);
            Controls.Add(EmployeePosition_Label);
            Controls.Add(EmployeeName_Input);
            Controls.Add(EmployeeName_Label);
            Controls.Add(SearchByEmployeeName_Button);
            Controls.Add(ShowAllEmployees_Button);
            Controls.Add(AddEmployee_Button);
            Controls.Add(BackButton);
            Controls.Add(EmployeesTitle_Label);
            Name = "EmployeesForm";
            Text = "CategoriesForm";
            Load += EmployeesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EmployeesTitle_Label;
        private Button BackButton;
        private Button AddEmployee_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllEmployees_Button;
        private Button SearchByEmployeeName_Button;
        private Button AddEmployeeInput_Button;
        private TextBox EmployeePosition_Input;
        private Label EmployeePosition_Label;
        private TextBox EmployeeName_Input;
        private Label EmployeeName_Label;
        private Label EmployeeSalary_Label;
        private TextBox EmployeeSalaryInput;
    }
}