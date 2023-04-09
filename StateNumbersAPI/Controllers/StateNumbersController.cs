using Application;
using Domain.Model;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using StateNumbersAPI.DTO;
using StateNumbersAPI.ModelValidation;

namespace StateNumbersAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class StateNumbersController : ControllerBase
   {
      private readonly INumberService _service;
     

      public StateNumbersController(INumberService service)
      {
         _service = service;
      }

      [HttpGet(nameof(GetStateNumberById))]
      public async Task<GetResponse> GetStateNumberById(int id)
      {
         try
         {
            var res = await _service.GetNumberById(id);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }


      [HttpPost(nameof(AddNumbers))]
      public async Task<GetResponse> AddNumbers(string number) 
      {
         try
         {
            var res = await _service.AddNumbers(new Numbers { Number = number });
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }

      [HttpPut(nameof(UpdateStateNumber))]
      public async Task<GetResponse> UpdateStateNumber(NumbersDTO numbers)
      {
         try
         {
            var res = await _service.UpdateNumbers(numbers);
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }

      [HttpDelete(nameof(DeleteStateNumber))]
      public async Task<GetResponse> DeleteStateNumber(NumbersDTO number)
      {
         try
         {
            var res = await _service.DeleteNumbers(number); 
            return new GetResponse { StatusCode = 200, Message = "Success", Result = res };
         }
         catch (Exception ex)
         {
            return new GetResponse { Message = ex.Message, StatusCode = 400 };
         }
      }

   }
}
