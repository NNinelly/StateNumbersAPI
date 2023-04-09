using Application;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public class BookNumberRepository :GenericRepository<BookNumbers>, IBookNumberRepository
   {
      public BookNumberRepository(APIDBContext dbContext) : base(dbContext)
      {

      }
   }
}
