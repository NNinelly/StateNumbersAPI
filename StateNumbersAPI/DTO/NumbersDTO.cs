namespace StateNumbersAPI.DTO
{
   public class NumbersDTO
   {
      public int id { get; set; }
      public string Number { get; set; }
      public DateTime CreateDate { get; set; }

      public class GetResponse : ResultClass
      {
         public bool Result { get; set; }
      }
   }
}
