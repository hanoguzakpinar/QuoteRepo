namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQueryRequest, Result<QuoteDto>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public GetQuoteQueryHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<Result<QuoteDto>> Handle(GetQuoteQueryRequest request, CancellationToken cancellationToken)
        {
            var quote = await _quoteService.GetByIdAsync(request.Id);
            var mapped = _mapper.Map<QuoteDto>(quote);
            return Result<QuoteDto>.Success(200, mapped);
        }
    }
}
