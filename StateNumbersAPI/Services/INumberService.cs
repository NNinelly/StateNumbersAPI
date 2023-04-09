using Domain.Model;
using StateNumbersAPI.DTO;
using StateNumbersAPI.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
   public interface INumberService 
   {
      public Task<bool> GetNumberById(int id);
      public Task<bool> AddNumbers(Numbers numbers);
      public Task<bool> UpdateNumbers(NumbersDTO numbers);
      public Task<bool> DeleteNumbers(NumbersDTO numbers);
   }
}
