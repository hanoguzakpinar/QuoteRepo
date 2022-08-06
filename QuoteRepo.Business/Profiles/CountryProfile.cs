namespace QuoteRepo.Business.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
