using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity> where Tentity : class, IEntity, new() where TContext : DbContext, new()
    {
        
        //Generic Mimari: Generic tip değişkenidir yukarıda ki kodda biz burada sadece TEntity tipinde değer gelebilir şeklinde şartladık bunu yapmamızın sebebi ürünler, kategoriler ya da class veri tiplerinin sadece TEntity yazan yere verilir şeklinde bir şarta soktuk TContext ise database nesnesidir. sadece NorthwindContext dosyasından türemedir harici başka bir yapıdan türetilmemeleridir. IEntityRepository ise bizim şartlarımız yani şablonlarımızdır Bunlar Add,List,Get,Update ya da Delete olmalıdır. where dediğimiz zaman aslında burada sarta sokmuş oluruz sadece TEntity tipinde sadece TContext tipinde class olmalıdır. new() ise burada bize newlenebilir özelliğii getirmektedir. Eğer new yazmazsak ürünler urun =new Urunler() şeklinde bir tanımlama yapmayız DbContext ise Entity Framework paketi içeren gelen ve bize db ile iletişime geçmemizi sağlayan classtır. Projeleri yazarken belli şartlara göre yazmalıyız bir düzen olmalıdır interface bize bir
        public void Add(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                //TContext nesnesi burada database nesnesi olarak geçmektedir. using bloğu içerisinde yazmamızın sebebi singleton 
                
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State=EntityState.Deleted;
                context.SaveChanges();
            }
        }
        //Public TEntity Get(Expression<Func<Tentity, bool>>filter)
        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (TContext context=new TContext()) 
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
                
            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<Tentity>().ToList() : context.Set<Tentity>().Where(filter).ToList();
            }
        }


        public void Update(Tentity entity)
        {
            using (TContext context=new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
