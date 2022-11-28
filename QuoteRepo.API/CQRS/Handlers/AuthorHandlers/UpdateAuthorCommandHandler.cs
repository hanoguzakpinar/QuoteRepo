using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    /*public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, AuthorDto>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public Task<AuthorDto> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public async Task<CountryDto> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateAuthorCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            /*if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);
            //await _authorService.UpdateAsync(_mapper.Map<UpdateAuthorDto>(request));
            return new CountryDto();
        }
    }*/
}
