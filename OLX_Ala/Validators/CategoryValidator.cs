using DataAccess.Data.Entities;
using FluentValidation;

namespace OLX_Ala.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1, 100);
        }
    }
}
