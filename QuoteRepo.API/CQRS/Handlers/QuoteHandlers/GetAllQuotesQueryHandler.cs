namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class GetAllQuotesQueryHandler : IRequestHandler<GetAllQuotesQueryRequest, Result<List<QuoteDto>>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public GetAllQuotesQueryHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<Result<List<QuoteDto>>> Handle(GetAllQuotesQueryRequest request, CancellationToken cancellationToken)
        {
            var quotes = await _quoteService.GetAllAsync();
            var mapped = _mapper.Map<List<QuoteDto>>(quotes);
            return Result<List<QuoteDto>>.Success(200, mapped);
        }
    }
}
