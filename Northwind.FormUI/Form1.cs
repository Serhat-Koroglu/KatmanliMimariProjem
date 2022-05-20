using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.FormUI
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        public IProductService _productService;
        public ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
            LoadCategories();
        }

        private void LoadProduct()
        {
            dataGridView1.DataSource=_productService.GetAll();
        }
        public void LoadCategories()
        {
            cbxCategories.DisplayMember="CategoryName";
            cbxCategories.ValueMember="CategoryID";
            cbxCategories.DataSource=_categoryService.GetAll();

            cbxUpdateCategories.DisplayMember="CategoryName";
            cbxUpdateCategories.ValueMember="CategoryID";
            cbxUpdateCategories.DataSource=_categoryService.GetAll();

            cbxAddCategories.DisplayMember="CategoryName";
            cbxAddCategories.ValueMember="CategoryID";
            cbxAddCategories.DataSource=_categoryService.GetAll();

            
        }

        private void tbxProducts_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxProducts.Text))
            {
                dataGridView1.DataSource=_productService.GetProductByProductc(tbxProducts.Text);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Entities.Concrete.Products
                {
                    CategoryID=Convert.ToInt32(cbxAddCategories.SelectedValue),
                    ProductName=tbxAddProductName.Text,
                    QuantityPerUnit=tbxQuantityPerUnit.Text,
                    UnitPrice=Convert.ToDecimal(tbxAddUnitPrice.Text),
                    UnitsInStock=Convert.ToInt16(tbxAddUnitsInStock.Text)
                });
                MessageBox.Show("Succesfull");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadProduct();
            LoadCategories();
        }

        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=_productService.GetProductByCategory(Convert.ToInt32(cbxCategories.SelectedValue));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            tbxUpdateProductName.Tag=row.Cells[0].Value;
            tbxUpdateProductName.Text=row.Cells[2].Value.ToString();
            cbxUpdateCategories.SelectedValue=row.Cells[1].Value.ToString();
            tbxUpdateUnitPrice.Text=row.Cells[5].Value.ToString();
            tbxUpdateQuantityPerUnit.Text=row.Cells[3].Value.ToString();
            tbxUpdateUnitsInStock.Text=row.Cells[4].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Entities.Concrete.Products
                {
                    ProductID=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                    ProductName=tbxUpdateProductName.Text,
                    CategoryID=Convert.ToInt32(cbxUpdateCategories.SelectedValue),
                    QuantityPerUnit=tbxUpdateQuantityPerUnit.Text,
                    UnitPrice=Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                    UnitsInStock=Convert.ToInt16(tbxUpdateUnitsInStock.Text)
                });
                MessageBox.Show("Update a product");
                LoadProduct();
                LoadCategories();

            }
            catch (SqlException exsql)
            {
                MessageBox.Show(exsql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Entities.Concrete.Products
            {
                ProductID=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("Deleted a product");
            LoadProduct();
            LoadCategories();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FormCategorys formCategorys = new FormCategorys();
            formCategorys.Show();
            this.Hide();
        }
    }
}
