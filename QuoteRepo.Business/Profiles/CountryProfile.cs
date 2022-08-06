using QuoteRepo.Entities.Core;
using QuoteRepo.Entities.Dtos;

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
