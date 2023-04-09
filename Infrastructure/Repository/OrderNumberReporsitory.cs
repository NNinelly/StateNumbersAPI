using Application;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public class OrderNumberReporsitory : GenericRepository<OrderNumbers>, IOrderNumberRepository
   {
      public OrderNumberReporsitory(APIDBContext dbContext) : base(dbContext)
      {

      }
   }
}
