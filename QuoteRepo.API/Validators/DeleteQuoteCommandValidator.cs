namespace QuoteRepo.API.CQRS.Commands.QuoteCommands
{
    public class DeleteQuoteCommandValidator : AbstractValidator<DeleteQuoteCommandRequest>
    {
        public DeleteQuoteCommandValidator()
        {
            RuleFor(q => q.Id).NotEmpty().GreaterThan(0);
        }
    }
}
