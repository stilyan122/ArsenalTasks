using MarketVault.Core.Services;
using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;

namespace MarketVault.UI
{
    public partial class CustomersForm : Form
    {
        private CustomerService customerService;

        public CustomersForm(ApplicationDbContext context)
        {
            this.customerService = new(context);

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
            AddCustomer_Button.Visible = false;
            CustomersWithNoOrders_Button.Visible = false;
            ShowAllCustomers_Button.Visible = false;

            CustomerName_Label.Visible = true;
            CustomerName_Input.Visible = true;
            CustomerEmail_Input.Visible = true;
            CustomerEmail_Label.Visible = true;
            AddCustomerInput_Button.Visible = true;
        }

        private void CategoriesByTotalStock_Button_Click(object sender, EventArgs e)
        {

        }

        private async void AddCustomerInput_Buttom_Click(object sender, EventArgs e)
        {
            string name = CustomerName_Input.Text;
            string email = CustomerEmail_Input.Text;

            Customer customer = new Customer() { Name = name, Email = email };

            await this.customerService
                .AddCustomerAsync(customer);

            MessageBox.Show("Added Customer!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CustomerName_Input.Clear();
            CustomerEmail_Input.Clear();
        }
    }
}
