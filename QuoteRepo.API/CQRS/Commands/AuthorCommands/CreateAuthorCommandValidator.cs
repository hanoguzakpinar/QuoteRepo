namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommandRequest>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.FullName).NotEmpty().MinimumLength(5);
            RuleFor(a => a.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(a => a.CountryId).NotEmpty().GreaterThan(0);
        }
    }
}
