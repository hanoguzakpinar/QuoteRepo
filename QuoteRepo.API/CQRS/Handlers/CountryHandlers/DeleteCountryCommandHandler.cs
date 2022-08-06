using MediatR;
using QuoteRepo.API.CQRS.Commands.CountryCommands;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, IDataResult<CountryDto>>
    {
        private readonly IRepository<Country> repository;

        public DeleteCountryCommandHandler(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public async Task<IDataResult<CountryDto>> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteCountryCommandValidator validator = new();
            var result = await validator.ValidateAsync(request, cancellationToken);
            if (result.Errors.Count > 0)
                return new DataResult<CountryDto>(ResultStatus.Error, errors: result.Errors);

            var country = await repository.GetAsync(c => c.Id == request.Id);
            if (country == null) return new DataResult<CountryDto>(ResultStatus.Error, message: "Country bulunamadı.");

            await repository.DeleteAsync(country);
            return new DataResult<CountryDto>(ResultStatus.Success, $"{request.Id} idli country silindi.");
        }
    }
}
