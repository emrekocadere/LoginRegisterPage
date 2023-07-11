using AutoMapper;
using bank_website_backend.Entities;
using bank_website_backend.Model.Request;

namespace bank_website_backend
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<User,RegisterRequest>().ReverseMap();
        }
    }
}
