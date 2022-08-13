namespace QuoteRepo.API.Profiles
{
    public class AuthorProfileApi : Profile
    {
        public AuthorProfileApi()
        {
            CreateMap<CreateAuthorDto, CreateAuthorCommandRequest>().ReverseMap();
            CreateMap<UpdateAuthorDto, UpdateAuthorCommandRequest>().ReverseMap();
        }
    }
}
