using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BookNumbers
   {
      public int Id { get; set; }
      public string Number { get; set; }
      public DateTime CreateDate { get; set; }
      public DateTime EndDate { get; set; }
      public bool Status { get; set; }

 
      public int NumberId { get; set; }
      public Numbers Numbers { get; set; }

   }


}
