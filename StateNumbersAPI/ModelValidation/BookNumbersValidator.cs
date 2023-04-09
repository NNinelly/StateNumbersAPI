using Domain.Model;
using FluentValidation;
using System.Security.Policy;

namespace StateNumbersAPI.ModelValidation
{
   public class BookNumbersValidator : AbstractValidator<BookNumbers>
   {
      public BookNumbersValidator()
      {
         RuleFor(n => n.NumberId).NotNull().NotEmpty();
      }
   }
}
