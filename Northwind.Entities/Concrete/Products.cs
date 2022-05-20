using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{

    [Table("Products")]// burada mapleme işlemi yapıldı yani db iletişim kurabilmesi için böyle bir işlem yapıldı. 
    public class Products:IEntity
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}
