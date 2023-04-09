using Application;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIDBContext _dbContext;
        public INumbersRepository Numbers { get; }
        public IBookNumberRepository BookNumbers { get; }
        public IOrderNumberRepository orderNumber { get; }

      public UnitOfWork(APIDBContext dbContext, INumbersRepository numbersRepository, 
         IBookNumberRepository bookRepository,
         IOrderNumberRepository orderRepository)
        {
           _dbContext = dbContext;
           Numbers = numbersRepository;
           BookNumbers = bookRepository;
           orderNumber = orderRepository;        
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
         await _dbContext.SaveChangesAsync();
        }
   }
}
