using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_Interfaces.BLL
{
    public interface IModelCollection<T> where T: class
    {
        void Add(T entity); 
        List<T> GetAll();
        T SearchByName(string name);

    }
}
