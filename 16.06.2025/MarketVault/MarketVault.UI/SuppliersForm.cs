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
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
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
            AddSupplier_Button.Visible = false;
            SuppliersByProduct_Button.Visible = false;
            ShowAllSuppliers_Button.Visible = false;
        }

        private void CategoriesByTotalStock_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
