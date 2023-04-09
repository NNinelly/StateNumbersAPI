using Domain.Model;
using FluentValidation;
using Markdig.Helpers;

namespace StateNumbersAPI.FluentValidation
{
   public class NumberValidator : AbstractValidator<Numbers>
   {
      public NumberValidator()
      {
         RuleFor(n => n.Number).NotNull().NotEmpty();         
         RuleFor(n => n.CreateDate)
            .NotEmpty().WithMessage("Create Date field is Required")
            .NotNull().WithMessage("Create Date cannot be null");       
      }

   }
}
