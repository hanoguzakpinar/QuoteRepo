﻿namespace QuoteRepo.API.Profiles
{
    public class AuthorProfileApi : Profile
    {
        public AuthorProfileApi()
        {
            CreateMap<AuthorDto, CreateAuthorCommandRequest>().ReverseMap();
        }
    }
}