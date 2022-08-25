namespace QuoteRepo.Business.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>().ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
        }
    }
}
