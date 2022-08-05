using FluentValidation;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommandRequest>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
