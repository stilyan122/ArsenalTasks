namespace MarketVault.UI
{
    partial class CategoriesForm
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
            CategoriesTitle_Label = new Label();
            BackButton = new Button();
            AddCategory_Button = new Button();
            ShowAllCategories_Button = new Button();
            CategoriesByTotalStock_Button = new Button();
            SuspendLayout();
            // 
            // CategoriesTitle_Label
            // 
            CategoriesTitle_Label.AutoSize = true;
            CategoriesTitle_Label.BackColor = Color.FromArgb(196, 225, 230);
            CategoriesTitle_Label.Font = new Font("Cambria", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoriesTitle_Label.ForeColor = Color.White;
            CategoriesTitle_Label.Location = new Point(655, 105);
            CategoriesTitle_Label.Name = "CategoriesTitle_Label";
            CategoriesTitle_Label.Padding = new Padding(25);
            CategoriesTitle_Label.Size = new Size(628, 120);
            CategoriesTitle_Label.TabIndex = 1;
            CategoriesTitle_Label.Text = "🗂️ Category Manager";
            CategoriesTitle_Label.Click += ProjectTitle_Label_Click;
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
            // AddCategory_Button
            // 
            AddCategory_Button.BackColor = Color.FromArgb(141, 188, 199);
            AddCategory_Button.Cursor = Cursors.Hand;
            AddCategory_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddCategory_Button.ForeColor = SystemColors.ControlLightLight;
            AddCategory_Button.Location = new Point(266, 458);
            AddCategory_Button.Name = "AddCategory_Button";
            AddCategory_Button.Size = new Size(308, 72);
            AddCategory_Button.TabIndex = 4;
            AddCategory_Button.Text = "➕ Add Category";
            AddCategory_Button.UseVisualStyleBackColor = false;
            AddCategory_Button.Click += AddCategory_Button_Click;
            // 
            // ShowAllCategories_Button
            // 
            ShowAllCategories_Button.BackColor = Color.FromArgb(141, 188, 199);
            ShowAllCategories_Button.Cursor = Cursors.Hand;
            ShowAllCategories_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowAllCategories_Button.ForeColor = SystemColors.ControlLightLight;
            ShowAllCategories_Button.Location = new Point(713, 458);
            ShowAllCategories_Button.Name = "ShowAllCategories_Button";
            ShowAllCategories_Button.Size = new Size(370, 72);
            ShowAllCategories_Button.TabIndex = 5;
            ShowAllCategories_Button.Text = "📋 Show All Categories";
            ShowAllCategories_Button.UseVisualStyleBackColor = false;
            // 
            // CategoriesByTotalStock_Button
            // 
            CategoriesByTotalStock_Button.BackColor = Color.FromArgb(141, 188, 199);
            CategoriesByTotalStock_Button.Cursor = Cursors.Hand;
            CategoriesByTotalStock_Button.Font = new Font("Cambria", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CategoriesByTotalStock_Button.ForeColor = SystemColors.ControlLightLight;
            CategoriesByTotalStock_Button.Location = new Point(1209, 458);
            CategoriesByTotalStock_Button.Name = "CategoriesByTotalStock_Button";
            CategoriesByTotalStock_Button.Size = new Size(389, 72);
            CategoriesByTotalStock_Button.TabIndex = 6;
            CategoriesByTotalStock_Button.Text = "📊 Categories by Total Stock";
            CategoriesByTotalStock_Button.UseVisualStyleBackColor = false;
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(141, 188, 199);
            ClientSize = new Size(1920, 1055);
            Controls.Add(CategoriesByTotalStock_Button);
            Controls.Add(ShowAllCategories_Button);
            Controls.Add(AddCategory_Button);
            Controls.Add(BackButton);
            Controls.Add(CategoriesTitle_Label);
            Name = "CategoriesForm";
            Text = "CategoriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CategoriesTitle_Label;
        private Button BackButton;
        private Button AddCategory_Button;
        private Button button1;
        private Button button2;
        private Button ShowAllCategories_Button;
        private Button CategoriesByTotalStock_Button;
    }
}