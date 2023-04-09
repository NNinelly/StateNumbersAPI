using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
   public interface IGenericRepository<T> where T:class
   {
     public Task<IEnumerable<T>> GetAllAsync();
      public Task<T> GetAsync(int id);
     public Task Add(T entity);
     public void Update(T entity);
     public void Delete(T entity);
     public void Save();

   }
}
