namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommandRequest>
    {
        public CreateQuoteCommandValidator()
        {
            RuleFor(a => a.Text).NotEmpty().MinimumLength(7);
            RuleFor(a => a.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
