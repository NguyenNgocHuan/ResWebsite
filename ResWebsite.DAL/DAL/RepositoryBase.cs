using ResWebsite.DAL.Interface1;
using ResWebsite.DAL.DAL;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Entity1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ResDbContext db ;
        private IDbSet<T> dbSet = null;
        public RepositoryBase(ResDbContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();
        }
        
        public bool CapNhat(T item)
        {
            try
            {
                dbSet.Attach(item);
               db.Entry(item).State = EntityState.Modified;
               // db.Set<T>().Re
               // db.SaveChanges();
              // db.Set<T>.sa
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public IEnumerable<T> LayTatCa()
        {
            try
            {
                return db.Set<T>();
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public bool ThemMoi(T item)
        {
            try
            {
                //dbSet.Add(item);
                //db.Entry(item).State = EntityState.Added;
                //db.SaveChanges();
                db.Set<T>().Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public T TimKiemTheoMa(string id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public bool Xoa(T item)
        {
            try
            {

                
               // db.Entry(item).State = EntityState.Deleted;
                dbSet.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
