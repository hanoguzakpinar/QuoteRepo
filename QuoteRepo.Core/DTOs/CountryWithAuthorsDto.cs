namespace QuoteRepo.Core.DTOs
{
    public class CountryWithAuthorsDto : CountryDto
    {
        public List<AuthorDto> Authors { get; set; }
    }
}
