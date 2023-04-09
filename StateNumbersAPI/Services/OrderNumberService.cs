using Application;
using Domain.Model;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StateNumbersAPI.DTO;

namespace StateNumbersAPI.Services
{
   public class OrderNumberService : IOrderNumberService
   {
      public IUnitOfWork _UoW;
      private readonly APIDBContext _DbContext;
      private readonly IValidator<OrderNumbers> validator;
      public OrderNumberService(IUnitOfWork uoW, APIDBContext context, IValidator<OrderNumbers> validator)
      {
         _UoW = uoW;
         _DbContext = context;
         this.validator = validator;
      }
    

      public async Task<bool> OrderNumber(int id)
      {
         var numbers = await _DbContext.Number.Where(x => x.Id == id).FirstOrDefaultAsync();
         if (_DbContext.BookNumbers.Any(x => x.NumberId == id && x.EndDate >= DateTime.Now))
         {
            throw new Exception("The Number is Booked");
         }
         var numb = new OrderNumbers
         {
            NumberId = numbers.Id,
            Number = numbers.Number,
            CreateDate = DateTime.Now,
            Status = true
         };

         await validator.ValidateAndThrowAsync(numb);
         await _UoW.orderNumber.Add(numb);
         await _UoW.CommitAsync();
         return true;
      }

      public async Task<bool> DeleteOrder(int id)
      {
         var numbers = await _DbContext.OrderNumbers.Where(x => x.Id == id).FirstOrDefaultAsync();

         numbers.Id = id;

         await validator.ValidateAndThrowAsync(numbers);
         _UoW.orderNumber.Delete(numbers);
         await _UoW.CommitAsync();
         return true;
      }
   }
}
