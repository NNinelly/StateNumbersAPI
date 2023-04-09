using System.ComponentModel.DataAnnotations.Schema;

namespace StateNumbersAPI.DTO
{
   public class BookNumbersDTO
   {
      public int Id { get; set; }
      public string Number { get; set; }
      public int NumberId { get; set; }
      public DateTime CreateDate { get; set; }
      public DateTime? EndDate { get; set; }
      public bool Status { get; set; }
   }
   public class GetResponse : ResultClass
   {
      public bool Result { get; set; }
   }
}
