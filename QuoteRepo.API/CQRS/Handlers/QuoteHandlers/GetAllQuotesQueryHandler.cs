using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class GetAllQuotesQueryHandler : IRequestHandler<GetAllQuotesQueryRequest, IDataResult<IList<QuoteDto>>>
    {
        private readonly IQuoteService _quoteService;

        public GetAllQuotesQueryHandler(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IDataResult<IList<QuoteDto>>> Handle(GetAllQuotesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _quoteService.GetAllAsync();
        }
    }
}
