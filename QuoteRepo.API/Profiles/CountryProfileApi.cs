namespace QuoteRepo.API.Profiles
{
    public class CountryProfileApi : Profile
    {
        public CountryProfileApi()
        {
            CreateMap<CountryDto, CreateCountryCommandRequest>().ReverseMap();
            CreateMap<CountryDto, UpdateCountryCommandRequest>().ReverseMap();
        }
    }
}
