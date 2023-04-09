using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateNumbersAPI.DTO;
using StateNumbersAPI.Services;

namespace StateNumbersAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class OrderNumberController : ControllerBase
   {
      private readonly IOrderNumberService _ent;


      public OrderNumberController(IOrderNumberService ent)
      {
         _ent = ent;
         
      }

      [HttpPost(nameof(AddOrder))]
      public async Task<GetResponse> AddOrder(int id)
      {
         try
         {
            var res = await _ent.OrderNumber(id);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }

      [HttpDelete(nameof(DeleteOrder))]
      public async Task<GetResponse> DeleteOrder(int id)
      {
         try
         {
            var res = await _ent.DeleteOrder(id);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }
   }
}
