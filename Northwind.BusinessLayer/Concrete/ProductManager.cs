using Northwind.BusinessLayer.Abstract;
using Northwind.BusinessLayer.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
       
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Products products)
        {
            ValidationTool.Validate(new ProductValidator(), products);
            _productDal.Add(products);
        }

        public void Delete(Products products)
        {
            _productDal.Delete(products);
        }

        public List<Products> GetAll()
        {
            return _productDal.GetAll();
        }

      
        public List<Products> GetProductByCategory(int categoryId)
        {
            return _productDal.GetAll(x => x.CategoryID == categoryId);
        }

        public List<Products> GetProductByProductc(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Products products)
        {
            ValidationTool.Validate(new ProductValidator(), products);
            _productDal.Update(products);
        }
    }
}
