using System;
using System.Collections.Generic;

namespace Shts_BLLInterfaces
{
    public interface IModelCollection<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll();

    }
}
