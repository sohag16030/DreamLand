using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestWeb.Core
{
    public interface ICrudRepository<E> where E: BaseEntity
    {
        //public List<E> GetList();
        //public E GetById(long id);
        //public EntityEntry<E> Create(E entity);
        //public EntityEntry<E> Update(E entity);
    }
}
