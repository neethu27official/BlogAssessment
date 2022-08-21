using BlogAssessment.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogAssessment.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region VariableDeclaration
        private ConnectionContext _context = null;
        private DbSet<T> table = null;
        #endregion

        #region Constructor
        public GenericRepository()
        {
            this._context = new ConnectionContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ConnectionContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Return all the data from table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        /// <summary>
        /// returns a single record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return table.Find(id);
        }
        /// <summary>
        /// inserts a record into table
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        /// <summary>
        /// updates the record
        /// </summary>
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        /// <summary>
        /// delete the record from table
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        /// <summary>
        /// To commit the changes
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}