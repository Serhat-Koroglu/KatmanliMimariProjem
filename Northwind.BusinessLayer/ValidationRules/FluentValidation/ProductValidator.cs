using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Products>
    {
        public ProductValidator()
        {
            /*
             * Projenin bu kısmı server tarafı olmaktadır. fluent validation paketi bize tam olarak nesnelerimizi korumak için kullandığımız bir pakettir yani ürün adı boş geçilemez HedefStokDuzeyi(UnitsInStock)boş geçileöez geçilirse hatalı bilgi logu düşsün burada her db korumuş oluyoruz temiz bilgi topluluğu için hemde nesneleri boş değer göndermesi için buna validatin işlemi denir.
             */
            RuleFor(p =>p.ProductName).NotEmpty();
            RuleFor(p =>p.CategoryID).NotEmpty();
            RuleFor(p =>p.UnitsInStock).NotEmpty();
            RuleFor(p =>p.UnitPrice).NotEmpty();
            RuleFor(p =>p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
        }
    }
}
