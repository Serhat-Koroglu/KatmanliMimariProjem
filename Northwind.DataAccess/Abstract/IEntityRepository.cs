using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        // T burada generic bir değerdir sadece class olmak zorundadır t dedigimiz için class vari tüm class yapısını t içine verebiliriz ama t ye class dısında bir sey verirsek hata alırız burada tipimizi sartlamıs olduk ve bunun dısında değer veremeyiz....

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        //(x=>x.UrunId==id).ToList();  bu yapıyı saglar bize...

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);





    }
}
