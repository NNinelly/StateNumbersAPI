using Azure.Core;
using Domain.Model;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StateNumbersAPI.DTO;
using StateNumbersAPI.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace Application
{
   public class NumberService : INumberService
   {
      public IUnitOfWork _UoW;
      private readonly APIDBContext _DbContext;
      private readonly IValidator<Numbers> validator;
      public NumberService(IUnitOfWork uoW, APIDBContext context, IValidator<Numbers> validator)
      {
         _UoW = uoW;
         _DbContext = context;
         this.validator = validator;
      }
      public async Task<bool> GetNumberById(int id)
      {
         var num = await _DbContext.Number.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

       if (num == null) 
         {
            throw new Exception("Please enter the data");
         }
         var number = new NumbersDTO
         {
            id = num.Id,
            Number = num.Number,
            CreateDate = num.CreateDate
         };
         await validator.ValidateAndThrowAsync(num);
         await _UoW.Numbers.GetAsync(num.Id);
         await _UoW.CommitAsync();

         return true;
      }

      public async Task<bool> AddNumbers(Numbers numbers)
      {
         if (_DbContext.Number.Any(i => i.Number == numbers.Number))
         {
            throw new Exception("This StateNumber Already Exist");

         }
         numbers.Number = string.Format(numbers.Number).ToUpper();
         numbers.CreateDate = DateTime.Now;

         await validator.ValidateAndThrowAsync(numbers);
         await _UoW.Numbers.Add(numbers);
         await _UoW.CommitAsync();
         return true;       
      }

      public async Task<bool> UpdateNumbers(NumbersDTO numbers)
      {
         var num = await _DbContext.Number.Where(x=> x.Id == numbers.id).FirstOrDefaultAsync();

         num.Id = numbers.id;
         num.Number = string.Format(numbers.Number).ToUpper();
         num.CreateDate = DateTime.Now;

         await validator.ValidateAndThrowAsync(num);
         _UoW.Numbers.Update(num);
         await _UoW.CommitAsync();

         return true;
      }

      public async Task<bool> DeleteNumbers(NumbersDTO numbers)
      {
         var num = await _DbContext.Number.Where(x => x.Id == numbers.id).FirstOrDefaultAsync();

         num.Id = numbers.id;
         num.Number = numbers.Number;

         await validator.ValidateAndThrowAsync(num);
         _UoW.Numbers.Delete(num);
         await _UoW.CommitAsync();

         return true;
      }    
   }
}
