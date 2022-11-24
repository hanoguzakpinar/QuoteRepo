namespace QuoteRepo.Data.Concrete.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Username).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(256);

            builder.HasOne(u => u.AppRole).WithMany(r => r.AppUsers).HasForeignKey(u => u.AppRoleId);

            builder.ToTable("Users");

            //builder.HasData(GetAppUsers());
        }

        private static IList<AppUser> GetAppUsers()
        {
            var users = new List<AppUser>
            {
                new AppUser { Id = 1, Username = "hanoguzakpinar", Password = "123", AppRoleId = 1 },
                new AppUser { Id = 2, Username = "member", Password = "123", AppRoleId = 2 }
            };
            return users;
        }
    }
}
