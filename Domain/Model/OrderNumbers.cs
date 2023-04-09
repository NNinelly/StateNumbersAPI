using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
   public class OrderNumbers
   {
      public int Id { get; set; }
      public string Number { get; set; }
      public DateTime CreateDate { get; set; }
      public bool Status { get; set; }


      public int NumberId { get; set; }
      public Numbers Numbers { get; set; }


   }
}
