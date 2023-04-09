using StateNumbersAPI.DTO;

namespace StateNumbersAPI.Services
{
   public interface IBookNumberService
   {
      public Task<bool> BookNumber(int id);
      public Task<bool> DeleteBooking(int id);
   }
}
