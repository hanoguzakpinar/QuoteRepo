using FluentValidation;

namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetCountryQueryValidator : AbstractValidator<GetCountryQueryRequest>
    {
        public GetCountryQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
