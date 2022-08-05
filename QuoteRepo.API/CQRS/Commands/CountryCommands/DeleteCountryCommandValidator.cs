using FluentValidation;

namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommandRequest>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
