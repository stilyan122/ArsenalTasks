using MarketVault.Core.Services;
using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;

namespace MarketVault.UI
{
    public partial class OrdersForm : Form
    {
        private OrderService orderService;
        public OrdersForm(ApplicationDbContext context)
        {
            this.orderService = new OrderService(context);

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
            AddOrder_Button.Visible = false;
            FilterByCustomer_Button.Visible = false;
            ShowAllOrders_Button.Visible = false;

            CustomerId_Input.Visible = true;
            CustomerId_Label.Visible = true;
            EmployeeId_Input.Visible = true;
            EmployeeId_Label.Visible = true;
            OrderPicker_Input.Visible = true;
            OrderDate_Label.Visible = true;
            AddOrderInput_Button.Visible = true;
        }

        private void CategoriesByTotalStock_Button_Click(object sender, EventArgs e)
        {

        }

        private async void AddOrderInput_Button_Click(object sender, EventArgs e)
        {
            DateTime orderDate = OrderPicker_Input.Value;
            int employeeId = int.Parse(EmployeeId_Input.Text);
            int customerId = int.Parse(CustomerId_Input.Text);

            Order order = new Order() { OrderDate = orderDate, EmployeeId = employeeId, CustomerId = customerId };

            await this.orderService
                .AddOrderAsync(order);

            MessageBox.Show("Added Order!", "Success",
              MessageBoxButtons.OK, MessageBoxIcon.Information);

            EmployeeId_Input.Clear();
            CustomerId_Input.Clear();
        }
    }
}
