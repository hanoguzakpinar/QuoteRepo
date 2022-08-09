namespace QuoteRepo.API.CQRS.Queries.AuthorQueries
{
    public class GetAuthorQueryValidator : AbstractValidator<GetAuthorQueryRequest>
    {
        public GetAuthorQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
