using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogAssessment.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        #region Methods
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        #endregion
    }
}