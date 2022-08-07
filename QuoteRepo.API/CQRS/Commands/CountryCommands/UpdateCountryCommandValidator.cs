namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommandRequest>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();
        }
    }
}
