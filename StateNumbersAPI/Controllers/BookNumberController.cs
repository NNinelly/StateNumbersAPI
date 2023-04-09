using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using StateNumbersAPI.DTO;
using StateNumbersAPI.Services;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace StateNumbersAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class BookNumberController : ControllerBase
   {
      private readonly IBookNumberService _ent;

      public BookNumberController(IBookNumberService ent)
      {
         _ent = ent;
      }

      [HttpPost(nameof(BookNumber))]
      public async Task<GetResponse> BookNumber(int id)
      {
         try
         {
            var res = await _ent.BookNumber(id);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }

      [HttpDelete(nameof(DeleteBooking))]
      public async Task<GetResponse> DeleteBooking(int id)
      {
         try
         {
            var res = await _ent.DeleteBooking(id);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }
   }
}
