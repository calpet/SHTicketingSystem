using System;
using System.Collections.Generic;
using System.Text;
using Shts_Entities.Enums;

namespace Shts_Interfaces.BLL
{
    public interface IModelCollection<T> where T: class
    {
        void Add(T entity);
        List<T> GetAll();
        T SearchBy(FilterSettings settings);

    }
}
