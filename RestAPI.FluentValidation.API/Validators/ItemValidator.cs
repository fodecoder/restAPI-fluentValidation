using FluentValidation;
using RestAPI.FluentValidation.Interfaces.Model;

namespace RestAPI.FluentValidation.API.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor ( customer => customer.Name ).NotNull ();
        }
    }
}
