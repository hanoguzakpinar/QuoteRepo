namespace QuoteRepo.Business.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteDto>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FullName));
            CreateMap<Quote, CreateQuoteDto>().ReverseMap();
            CreateMap<Quote, UpdateQuoteDto>().ReverseMap();
        }
    }
}
