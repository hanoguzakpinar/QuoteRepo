namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommandRequest, Result<CreateQuoteCommandRequest>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper, IAuthorService authorService)
        {
            _quoteService = quoteService;
            _mapper = mapper;
            _authorService = authorService;
        }

        public async Task<Result<CreateQuoteCommandRequest>> Handle(CreateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            var hasEntity = await _authorService.AnyAsync(a => a.Id == request.AuthorId);
            if (!hasEntity) { throw new NotFoundException(Message.NotFound<Author>(request.AuthorId)); }

            var quote = await _quoteService.AddAsync(_mapper.Map<Quote>(request));
            return Result<CreateQuoteCommandRequest>.Success(201, request);
        }
    }
}
