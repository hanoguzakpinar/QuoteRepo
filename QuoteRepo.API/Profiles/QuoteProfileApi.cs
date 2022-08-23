namespace QuoteRepo.API.Profiles
{
    public class QuoteProfileApi : Profile
    {
        public QuoteProfileApi()
        {
            CreateMap<CreateQuoteDto, CreateQuoteCommandRequest>().ReverseMap();
            CreateMap<UpdateQuoteDto, UpdateQuoteCommandRequest>().ReverseMap();
        }
    }
}
