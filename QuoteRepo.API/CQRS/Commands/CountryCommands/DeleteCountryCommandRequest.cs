namespace QuoteRepo.API.CQRS.Commands.CountryCommands
{
    public class DeleteCountryCommandRequest : IRequest<Result<NoContentDto>>
    {
        public int Id { get; set; }
        public DeleteCountryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
