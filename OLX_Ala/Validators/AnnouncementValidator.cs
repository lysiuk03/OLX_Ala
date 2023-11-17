using DataAccess.Data.Entities;
using FluentValidation;

namespace OLX_Ala.Validators
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(1, 100);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ImageURL).Must(ValidateUrl).WithMessage("{PropertyName} must be a valid URL address.");
            RuleFor(x => x.Discount).InclusiveBetween(0, 100);
            RuleFor(x => x.Description).Length(10, 1000);
            RuleFor(x => x.ContactName).NotNull().Length(1, 100);
            RuleFor(x => x.Phone).Matches(@"^(\+\d{1,4}|\(\+\d{1,4}\))?-?\d{6,14}$").WithMessage("Incorrect phone number format.");
            RuleFor(x => x.CategoryId).NotEqual(0).WithMessage("{PropertyName} not valid");
            RuleFor(x => x.RegionId).NotEqual(0).WithMessage("{PropertyName} not valid"); ;
        }

        public bool ValidateUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult))
            {
                return uriResult != null && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }

            return false;
        }
    }
}
