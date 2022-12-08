namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommandRequest, Result<NoContentDto>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public UpdateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper, IAuthorService authorService)
        {
            _quoteService = quoteService;
            _mapper = mapper;
            _authorService = authorService;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            var hasEntity = await _authorService.AnyAsync(a => a.Id == request.AuthorId);
            if (!hasEntity) { throw new NotFoundException(Message.NotFound<Author>(request.AuthorId)); }

            await _quoteService.UpdateAsync(_mapper.Map<Quote>(request));
            return Result<NoContentDto>.Success(204);
        }
    }
}
