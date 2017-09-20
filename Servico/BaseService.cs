using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class BaseService<T> : IGenericService<T> where T : class, IModel<int>
    {
        public DbContext Context { get; set; }

        public BaseService()
        {
            Context = new Contexto();
        }

        protected IDbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public virtual void Delete(int id)
        {
            T entity = Get(id);

            if (entity == null)
                throw new ArgumentNullException();

            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return DbSet.SingleOrDefault(filter);
        }

        public int GetCount()
        {
            return DbSet.Count<T>();
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            return DbSet.Count<T>(filter);
        }

        public virtual IQueryable<T> Load()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<T> Load(Expression<Func<T, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public virtual void Save(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(int id, T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

            if (id != entity.Id)
                throw new ArgumentOutOfRangeException("Id Inválido");

            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EntityExists(id))
                    throw new ArgumentOutOfRangeException("Id Inválido", ex);
                else
                    throw;
            }
        }

        private bool EntityExists(int id)
        {
            return DbSet.Any(e => e.Id == id);
        }
    }
}
