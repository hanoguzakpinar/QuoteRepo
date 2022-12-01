namespace QuoteRepo.Core.Models
{
    public class AppRole : BaseEntity
    {
        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}
