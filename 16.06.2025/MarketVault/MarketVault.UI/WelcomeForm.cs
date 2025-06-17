using MarketVault.Infrastructure.DbContexts;

namespace MarketVault.UI
{
    public partial class WelcomeForm : Form
    {
        private ApplicationDbContext context;

        public WelcomeForm()
        {
            this.context = new();

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageCustomers_Button.Visible = true;
            ManageCategories_Button.Visible = true;
            ManageOrders_Button.Visible = true;
            ManageProducts_Button.Visible = true;
            ManageEmployees_Button.Visible = true;
            ManageSuppliers_Button.Visible = true;
        }

        private void ManagaCategories_Button_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm(context);

            this.Hide();
            categoriesForm.Show();
        }

        private void ManageProducts_Button_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();

            this.Hide();
            productsForm.Show();
        }

        private void ManageCustomers_Button_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm(context);

            this.Hide();
            customersForm.Show();
        }

        private void ManageSuppliers_Button_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm();

            this.Hide();
            suppliersForm.Show();
        }

        private void ManageOrders_Button_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm(context);

            this.Hide();
            ordersForm.Show();
        }

        private void ManageEmployees_Button_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(context);

            this.Hide();
            employeesForm.Show();
        }
    }
}
