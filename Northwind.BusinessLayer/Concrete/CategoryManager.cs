using Northwind.BusinessLayer.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
           _categoryDal = categoryDal;
        }
        public void Add(Categories categories)
        {
            _categoryDal.Add(categories);
        }

        public void Delete(Categories categories)
        {
            _categoryDal.Delete(categories);
        }

        public List<Categories> GetAll()
        {
           return _categoryDal.GetAll();
        }

        public List<Categories> GetProductByCategory(int categoryId)
        {
            return _categoryDal.GetAll(x => x.CategoryID == categoryId);
        }

        public List<Categories> GetProductByProductc(string categoryName)
        {
            return _categoryDal.GetAll(x => x.CategoryName == categoryName);
        }
        public List<Categories> GetCategoryByCategory(string categoryName)
        {
            return _categoryDal.GetAll(p => p.CategoryName.ToLower().Contains(categoryName.ToLower()));
        }
        public void Update(Categories categories)
        {
            _categoryDal.Update(categories);
        }
    }
}
