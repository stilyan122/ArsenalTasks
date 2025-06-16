namespace MarketVault.UI
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
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
            CategoriesForm categoriesForm = new CategoriesForm();

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
            CustomersForm customersForm = new CustomersForm();

            this.Hide();
            customersForm.Show();
        }

        private void ManageSuppliers_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
