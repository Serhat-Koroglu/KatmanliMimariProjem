using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
        List<Categories> GetProductByCategory(int productId);
        List<Categories> GetProductByProductc(string categoryName);
        List<Categories> GetCategoryByCategory(string productName);
        void Add(Categories categories);
        void Update(Categories categories);
        void Delete(Categories categories);
    }
}
