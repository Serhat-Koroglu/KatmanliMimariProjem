

using Northwind.Entities.Concrete;
using System.Data.Entity;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class NortwindContext:DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        
    }
}
