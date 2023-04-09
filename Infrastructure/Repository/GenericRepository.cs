using Application;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
   {
      protected readonly APIDBContext _dbContext;
      internal DbSet<T> DbSet { get; set; }
      public GenericRepository(APIDBContext apiDb)
      {
         this._dbContext = apiDb;
         this.DbSet = this._dbContext.Set<T>();
      }

      public async Task<IEnumerable<T>> GetAllAsync()
      {
         return await _dbContext.Set<T>().ToListAsync();
      }

      public async Task<T> GetAsync(int id)
      {
         return await _dbContext.Set<T>().FindAsync(id);
      }

      public async Task Add(T entity)
      {
         await _dbContext.Set<T>().AddAsync(entity);
      }

      public void Update(T entity)
      {
         _dbContext.Set<T>().Update(entity);
         
      }
      public void Delete(T entity)
      {
         _dbContext.Set<T>().Remove(entity);
      }
      public void Save()
      {
         _dbContext.SaveChanges();
      }
   }
}
