using MarketVault.Core.Services;
using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketVault.UI
{
    public partial class EmployeesForm : Form
    {
        private EmployeeService employeeService;

        public EmployeesForm(ApplicationDbContext context)
        {
            this.employeeService = new EmployeeService(context);

            InitializeComponent();
        }

        private void ProjectTitle_Label_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        private void AddCategory_Button_Click(object sender, EventArgs e)
        {
            AddEmployee_Button.Visible = false;
            SearchByEmployeeName_Button.Visible = false;
            ShowAllEmployees_Button.Visible = false;

            EmployeeName_Label.Visible = true;
            EmployeeName_Input.Visible = true;
            EmployeePosition_Label.Visible = true;
            EmployeePosition_Input.Visible = true;
            EmployeeSalary_Label.Visible = true;
            EmployeeSalaryInput.Visible = true;
            AddEmployeeInput_Button.Visible = true;
        }

        private void CategoriesByTotalStock_Button_Click(object sender, EventArgs e)
        {

        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {

        }

        private async void AddEmployeeInput_Button_Click(object sender, EventArgs e)
        {
            string name = EmployeeName_Input.Text;
            string position = EmployeePosition_Input.Text;
            decimal salary = decimal.Parse(EmployeeSalaryInput.Text);

            Employee employee = new Employee() { Name = name, Position = position, Salary = salary };

            await this.employeeService
                .AddEmployeeAsync(employee);

            MessageBox.Show("Added Employee!", "Success",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

            EmployeeName_Input.Clear();
            EmployeePosition_Input.Clear();
            EmployeeSalaryInput.Clear();
        }
    }
}
