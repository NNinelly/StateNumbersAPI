namespace StateNumbersAPI.DTO
{
   public class OrderNumberDTO
   {
      public int Id { get; set; }
      public string Number { get; set; }
      public DateTime CreateDate { get; set; }
      public bool Status { get; set; }

      public class GetResponse : ResultClass
      {
         public bool Result { get; set; }
      }
   }
}
