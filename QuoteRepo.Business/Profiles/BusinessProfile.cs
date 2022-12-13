namespace QuoteRepo.Business.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorWithQuotesDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<Country, CountryWithAuthorsDto>().ReverseMap();
            CreateMap<Quote, QuoteDto>().ReverseMap();
            CreateMap<Quote, CreateQuoteDto>().ReverseMap();
            CreateMap<Quote, UpdateQuoteDto>().ReverseMap();
        }
    }
}
