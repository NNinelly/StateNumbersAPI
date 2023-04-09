using Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
   public interface IUnitOfWork : IDisposable
   {
      INumbersRepository Numbers { get; }
      IBookNumberRepository BookNumbers { get; }
      IOrderNumberRepository orderNumber { get; }
      void Commit();
      Task CommitAsync();
   }
}
