using MediatR;
using QuoteRepo.API.CQRS.Commands.CountryCommands;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;

namespace QuoteRepo.API.CQRS.CountryHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest>
    {
        private readonly IRepository<Country> repository;

        public CreateCountryCommandHandler(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.AddAsync(new Country { Name = request.Name });
            return Unit.Value;
        }
    }
}
