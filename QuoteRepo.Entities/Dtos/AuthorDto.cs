namespace QuoteRepo.Entities.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
    }
}
