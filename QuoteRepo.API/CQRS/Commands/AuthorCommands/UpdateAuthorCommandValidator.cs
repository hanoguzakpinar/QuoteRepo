namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommandRequest>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
            RuleFor(a => a.FullName).NotEmpty().MinimumLength(5);
            RuleFor(a => a.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(a => a.CountryId).NotEmpty().GreaterThan(0);
        }
    }
}
