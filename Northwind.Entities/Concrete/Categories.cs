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
    [Table("Categories")]
    public class Categories:IEntity
  //Ientity burada implemente ediyoruz erişimin kolay olması için

    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
