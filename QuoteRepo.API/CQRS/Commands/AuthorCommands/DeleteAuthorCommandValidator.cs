namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommandRequest>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
