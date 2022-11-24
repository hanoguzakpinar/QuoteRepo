using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, IResult>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IResult> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteAuthorCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _authorService.DeleteAsync(request.Id);
        }
    }
}
