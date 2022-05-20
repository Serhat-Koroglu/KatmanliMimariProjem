using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLayer.ValidationRules.FluentValidation
{
    public class ValidationTool
    {
        //Generic olarak gelen entity tipindeki class alıp içerisinde uygun olmayam bir durum olduğunda error olarak validationExceptiondan hata verecektir.
        public static void Validate<T>(IValidator<T> validator,T entity)
        {
            var validationResult = validator.Validate(entity);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
