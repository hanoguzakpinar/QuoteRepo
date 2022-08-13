﻿namespace QuoteRepo.API.CQRS.Commands.AuthorCommands
{
    public class UpdateAuthorCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}