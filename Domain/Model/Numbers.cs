using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Numbers
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }


      public virtual ICollection<BookNumbers> BookNumbers { get; set; }
      public virtual ICollection<OrderNumbers> OrderNumbers { get; set; }
   }
}
