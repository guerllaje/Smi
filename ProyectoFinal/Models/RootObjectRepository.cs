using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProyectoFinal.Models
{ 
    public class RootObjectRepository : IRootObjectRepository
    {
        PatientModelDBContext context = new PatientModelDBContext();

        public IQueryable<RootObject> All
        {
            get { return context.RootObjects; }
        }

        public IQueryable<RootObject> AllIncluding(params Expression<Func<RootObject, object>>[] includeProperties)
        {
            IQueryable<RootObject> query = context.RootObjects;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public RootObject Find(int id)
        {
            return context.RootObjects.Find(id);
        }

        public void InsertOrUpdate(RootObject rootobject)
        {
            if (rootobject.id == default(int)) {
                // New entity
                context.RootObjects.Add(rootobject);
            } else {
                // Existing entity
                context.Entry(rootobject).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var rootobject = context.RootObjects.Find(id);
            context.RootObjects.Remove(rootobject);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IRootObjectRepository : IDisposable
    {
        IQueryable<RootObject> All { get; }
        IQueryable<RootObject> AllIncluding(params Expression<Func<RootObject, object>>[] includeProperties);
        RootObject Find(int id);
        void InsertOrUpdate(RootObject rootobject);
        void Delete(int id);
        void Save();
    }
}