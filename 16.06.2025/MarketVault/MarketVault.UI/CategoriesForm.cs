using MarketVault.Core.Services;
using MarketVault.Infrastructure.DbContexts;
using MarketVault.Infrastructure.Models;

namespace MarketVault.UI
{
    public partial class CategoriesForm : Form
    {
        private CategoryService categoryService;

        public CategoriesForm(ApplicationDbContext context)
        {
            this.categoryService = new(context);

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
            AddCategory_Button.Visible = false;
            CategoriesByTotalStock_Button.Visible = false;
            ShowAllCategories_Button.Visible = false;

            CategoryName_Input.Visible = true;
            CategoryName_Label.Visible = true;
            AddCategoryNameInput_Button.Visible = true;
        }

        private void CategoryName_Label_Click(object sender, EventArgs e)
        {

        }

        private async void AddCategoryNameInput_Button_Click(object sender, EventArgs e)
        {
            string name = CategoryName_Input.Text;

            Category category = new() { Name = name };

            await this.categoryService
                .AddCategoryAsync(category);

            MessageBox.Show("Added Product!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CategoryName_Input.Clear();
        }
    }
}
