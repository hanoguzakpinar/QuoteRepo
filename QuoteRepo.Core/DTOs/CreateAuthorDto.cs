namespace QuoteRepo.Core.DTOs
{
    public class CreateAuthorDto
    {
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}
