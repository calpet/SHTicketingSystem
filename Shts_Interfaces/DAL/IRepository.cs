using System;
using System.Collections.Generic;

namespace Shts_Interfaces
{
    public interface IRepository<T> where T: class
    {
        void Create(T entity);
        void Edit(T entity);
        void Delete(int id);
        List<T> GetAll();
    }
}
