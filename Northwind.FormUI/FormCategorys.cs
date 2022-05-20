using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.DependencyResolvers.Ninject;


namespace Northwind.FormUI
{
    public partial class FormCategorys : Form
    {
        public FormCategorys()
        {
            InitializeComponent();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        public ICategoryService _categoryService;
        private void FormCategorys_Load(object sender, EventArgs e)
        {
            CategoryLoad();
        }

        private void CategoryLoad()
        {
            dgwCategorys.DataSource=_categoryService.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.Add(new Entities.Concrete.Categories
                {
                    CategoryName=tbxAddCategoryName.Text,
                    Description=tbxAddDescription.Text
                });
                MessageBox.Show("Succesfull!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CategoryLoad();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.Delete(new Entities.Concrete.Categories
                {
                    CategoryID=Convert.ToInt32(dgwCategorys.CurrentRow.Cells[0].Value)

                });
                MessageBox.Show("Deleted a category!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata! Kategorinin içinde ürün var silinemez... ",ex.Message);
            }
            CategoryLoad();
        }

        private void dgwCategorys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwCategorys.CurrentRow;
            tbxUpdateCategoryName.Tag=row.Cells[0].Value;
            tbxUpdateCategoryName.Text=row.Cells[1].Value.ToString();
            tbxUpdateDescription.Text=row.Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.Update(new Entities.Concrete.Categories
                {
                    CategoryID=Convert.ToInt32(dgwCategorys.CurrentRow.Cells[0].Value),
                    CategoryName=tbxUpdateCategoryName.Text,
                    Description=tbxUpdateDescription.Text
                });
                MessageBox.Show("Update a Category!");
                CategoryLoad();
            }
            catch (SqlException exsql)
            {
                MessageBox.Show("Error! {0}",exsql.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxSearch.Text))
            {
                dgwCategorys.DataSource=_categoryService.GetCategoryByCategory(tbxSearch.Text.ToLower());
            }
            else
            {
                CategoryLoad();
            }
            
           
        }
    }
}
