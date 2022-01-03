using Application.Features.Colors;
using FluentValidation;
using static Colors.Domain.Common.ModelConstants;

namespace Application.Features.People.Commands.Create
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator(IColorsRepository colorsRepository)
        {
            this.RuleFor(p => p.FirstName)
                .MinimumLength(NameMinLength)
                .MaximumLength(NameMaxLength);

            this.RuleFor(p => p.LastName)
                .MinimumLength(NameMinLength)
                .MaximumLength(NameMaxLength);

            this.RuleFor(p => p.Zipcode)
                .Matches(ZipcodeRegexPattern)
                .WithMessage("Zipcode must be exactly 5 numbers");

            this.RuleFor(p => p.City)
                .MinimumLength(CityMinLength)
                .MaximumLength(CityMaxLength);

            this.RuleFor(p => p.Color)
                .MustAsync(async (color, token) => await colorsRepository
                .GetColorByName(color, token) != null)
                .WithMessage("Color does not exist");
        }
    }
}
