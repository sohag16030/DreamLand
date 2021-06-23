using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestWeb.DbContexts;

namespace TestWeb.Core
{
    public class CrudRepository<E> : ICrudRepository<E> 
        where E: BaseEntity
    {
        private DbSet <E> _entities;
        //private AppDbContext _dbContext;

        //protected CrudRepository(AppDbContext contextR)
        //{
        //    _dbContext = contextR;
        //    _entities = contextR.Set<E>();
        //}

        public List<E> GetList()
        {
            return _entities.Where(e => e.IsActive == true).ToList();
        }

        public E GetById(long id)
        {
            return _entities.First(e => e.IsActive == true && e.IntId == id);
        }

        //public EntityEntry<E> Create(E entity)
        //{
        //    entity.DteServerDateTime = DateTime.UtcNow;
        //    entity.DteLastActionDateTime = DateTime.UtcNow;
        //    EntityEntry<E> createdEntity  = _entities.Add(entity);
        //    _dbContext.SaveChanges();
        //    return createdEntity;
        //}

        //public EntityEntry<E> Update(E entity)
        //{
        //    entity.DteServerDateTime = DateTime.UtcNow;
        //    entity.DteLastActionDateTime = DateTime.UtcNow;
        //    entity.IsActive = true;
        //    EntityEntry<E> createdEntity = _entities.Update(entity);
        //    _dbContext.SaveChanges();
        //    return createdEntity;
        //}
    }
}
