using StateNumbersAPI.DTO;

namespace StateNumbersAPI.Services
{
   public interface IOrderNumberService
   {
      public Task<bool> OrderNumber(int id);
      public Task<bool> DeleteOrder(int id);
      
   }
}
