namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class UpdateQuoteCommandValidator : AbstractValidator<UpdateQuoteCommandRequest>
    {
        public UpdateQuoteCommandValidator()
        {
            RuleFor(a => a.Text).NotEmpty().MinimumLength(7);
            RuleFor(a => a.AuthorId).NotEmpty().GreaterThan(0);
        }
    }
}
