using AutoMapper;
using MediatR;
using QuoteRepo.API.CQRS.Commands.CountryCommands;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Entities.Core;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, Result>
    {
        private readonly IRepository<Country> repository;

        public DeleteCountryCommandHandler(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = await repository.GetAsync(c => c.Id == request.Id);
            if (country == null) return new Result("Country bulunamadı.");

            await repository.DeleteAsync(country);
            return new Result($"{request.Id}idli country başarıyla silindi.");
        }
    }
}
