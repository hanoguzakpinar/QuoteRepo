namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, Result<NoContentDto>>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<NoContentDto>> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorService.GetByIdAsync(request.Id);
            await _authorService.DeleteAsync(author);
            return Result<NoContentDto>.Success(204);
        }
    }
}
