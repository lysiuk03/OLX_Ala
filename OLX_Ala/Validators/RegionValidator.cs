using DataAccess.Data.Entities;
using FluentValidation;

namespace OLX_Ala.Validators
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1, 100);
        }
    }
}
