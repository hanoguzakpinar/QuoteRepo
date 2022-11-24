using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQueryRequest, IDataResult<QuoteDto>>
    {
        private readonly IQuoteService _quoteService;

        public GetQuoteQueryHandler(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IDataResult<QuoteDto>> Handle(GetQuoteQueryRequest request, CancellationToken cancellationToken)
        {
            GetQuoteQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new DataResult<QuoteDto>(ResultStatus.Error, errors: valResult.Errors);

            return await _quoteService.GetAsync(request.Id);
        }
    }
}
