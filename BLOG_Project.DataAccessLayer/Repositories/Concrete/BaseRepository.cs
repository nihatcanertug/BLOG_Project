using BLOG_Project.DataAccessLayer.Context;
using BLOG_Project.DataAccessLayer.Repositories.Interfaces;
using BLOG_Project.EntityLayer.Entities.Concrete;
using BLOG_Project.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.DataAccessLayer.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _context;
        public BaseRepository() => _context = new ProjectContext();
               
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);


        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();


        public List<T> GetAll() => _context.Set<T>().ToList();

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();
        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Passive;
            item.DeleteDate = DateTime.Now;
            Save();
        }

        public int Save() => _context.SaveChanges();

        public void Update(T item)
        {
            T updatedItem = GetById(item.Id);// We found the object to be updated over the value kept on the "Id" proportion of the item object that will come from the user and filled it into an object named "updatedItem", which is a "T" type.
            DbEntityEntry dbEntityEntry = _context.Entry(updatedItem); //We got the values on the "updatedItem" object via "Entry", which is an embedded method of the //"DbContext.cs "class.
            dbEntityEntry.CurrentValues.SetValues(item); // Finally, we set the values above the "item" object received by the user to the existing values of the object that we find and retrieve in the database and fill the values on "dbEntityEntry".
            Save();
        }
    }

}
