using Domain.Model;
using FluentValidation;

namespace StateNumbersAPI.ModelValidation
{
   public class OrderNumbersValidator : AbstractValidator<OrderNumbers>
   {
      public OrderNumbersValidator()
      {
         RuleFor(n => n.NumberId).NotNull().NotEmpty();
      }
   }
}
