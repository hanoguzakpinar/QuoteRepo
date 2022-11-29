namespace QuoteRepo.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CountryDto, CreateCountryCommandRequest>().ReverseMap();
            CreateMap<Country, CreateCountryCommandRequest>().ReverseMap();
            CreateMap<CountryDto, UpdateCountryCommandRequest>().ReverseMap();
            CreateMap<Country, UpdateCountryCommandRequest>().ReverseMap();
            CreateMap<CreateAuthorDto, CreateAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, CreateAuthorCommandRequest>().ReverseMap();
            CreateMap<UpdateAuthorDto, UpdateAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommandRequest>().ReverseMap();
            CreateMap<CreateQuoteDto, CreateQuoteCommandRequest>().ReverseMap();
            CreateMap<Quote, CreateQuoteCommandRequest>().ReverseMap();
            CreateMap<UpdateQuoteDto, UpdateQuoteCommandRequest>().ReverseMap();
            CreateMap<Quote, UpdateQuoteCommandRequest>().ReverseMap();
        }
    }
}
