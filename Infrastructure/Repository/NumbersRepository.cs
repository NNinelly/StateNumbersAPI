using Application;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class NumbersRepository : GenericRepository<Numbers>, INumbersRepository
   {
      public NumbersRepository(APIDBContext dbContext): base(dbContext)
      {

      }

   }
}
