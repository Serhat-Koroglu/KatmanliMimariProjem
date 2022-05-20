using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Abstract
{
   public interface IProductService
    {
        List<Products> GetAll();
        List<Products> GetProductByCategory(int categoryId);
        List<Products> GetProductByProductc(string productName);
       
        void Add(Products products);
        void Update(Products products);
        void Delete(Products products);
    }
}
