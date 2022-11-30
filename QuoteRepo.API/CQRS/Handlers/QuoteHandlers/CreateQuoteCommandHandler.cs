namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommandRequest, Result<CreateQuoteCommandRequest>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<Result<CreateQuoteCommandRequest>> Handle(CreateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            var quote = await _quoteService.AddAsync(_mapper.Map<Quote>(request));
            return Result<CreateQuoteCommandRequest>.Success(201, request);
        }
    }
}
