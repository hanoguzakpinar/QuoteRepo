namespace QuoteRepo.Business.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteDto>().ReverseMap();
            CreateMap<Quote, CreateQuoteDto>().ReverseMap();
        }
    }
}
