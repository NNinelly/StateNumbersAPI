using Application;
using Domain.Model;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StateNumbersAPI.DTO;
using StateNumbersAPI.ModelValidation;
using System;

namespace StateNumbersAPI.Services
{
   public class BookNumberService : IBookNumberService
   {
      public IUnitOfWork _UoW;
      private readonly APIDBContext _DbContext;
      private readonly IValidator<BookNumbers> validator;
      public BookNumberService(IUnitOfWork uoW, APIDBContext context, IValidator<BookNumbers> validator)
      {
         _UoW = uoW;
         _DbContext = context;
         this.validator = validator;

      }
      public async Task<bool> BookNumber(int id)
      {
         var numbers = await _DbContext.Number.Where(x => x.Id == id).FirstOrDefaultAsync();
         if (_DbContext.BookNumbers.Any(i => i.NumberId == id))
         {
            throw new Exception("The Number is Booked");

         }
        if (_DbContext.OrderNumbers.Any(x => x.NumberId == id))
         {
            throw new Exception("The Number is out of stock");
         }
         var numb = new BookNumbers
         {
            NumberId = numbers.Id,
            Number = numbers.Number,
            CreateDate = DateTime.Now,
            EndDate = DateTime.Now.AddMinutes(30.00),
            Status = true
         };
         await validator.ValidateAndThrowAsync(numb);
         await _UoW.BookNumbers.Add(numb);
         await _UoW.CommitAsync();
         return true;
      }

      public async Task<bool> DeleteBooking(int id)
      {
         var numbers = await _DbContext.BookNumbers.Where(x => x.Id == id).FirstOrDefaultAsync();
         numbers.Id =id;

         await validator.ValidateAndThrowAsync(numbers);
          _UoW.BookNumbers.Delete(numbers);
         await _UoW.CommitAsync();

         return true;

      }
   }
}
