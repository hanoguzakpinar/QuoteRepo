namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetQuoteQueryValidator : AbstractValidator<GetQuoteQueryRequest>
    {
        public GetQuoteQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty().GreaterThan(0);
        }
    }
}
