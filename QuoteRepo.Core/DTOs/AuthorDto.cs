namespace QuoteRepo.Core.DTOs
{
    public class AuthorDto : BaseDto
    {
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}
