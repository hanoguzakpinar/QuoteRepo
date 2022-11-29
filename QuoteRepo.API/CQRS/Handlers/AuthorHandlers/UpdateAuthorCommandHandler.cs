namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, Result<NoContentDto>>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            await _authorService.UpdateAsync(_mapper.Map<Author>(request));
            return Result<NoContentDto>.Success(204);
        }
    }
}
