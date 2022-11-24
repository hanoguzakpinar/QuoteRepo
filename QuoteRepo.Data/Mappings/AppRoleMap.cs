namespace QuoteRepo.Data.Mappings
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Definition).IsRequired().HasMaxLength(40);

            builder.HasMany(r => r.AppUsers).WithOne(u => u.AppRole).HasForeignKey(r => r.AppRoleId);

            builder.ToTable("Roles");

            builder.HasData(GetRoles());
        }

        private static IList<AppRole> GetRoles()
        {
            var roles = new List<AppRole>
            {
                new AppRole { Id = 1, Definition = "Admin" },
                new AppRole { Id = 2, Definition = "Member" }
            };
            return roles;
        }
    }
}
