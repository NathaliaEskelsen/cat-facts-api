using AutoMapper;
using CatFacts.Dtos;
using CatFacts.Models;

namespace CatFacts.Profiles
{
    public class CatsProfile : Profile
    {
        //Source -> Target
        public CatsProfile()
        {
            CreateMap<Cat, CatReadDto>();
            CreateMap<CatCreateDto, Cat>();
            CreateMap<CatUpdateDto, Cat>();
            CreateMap<Cat, CatUpdateDto>();

        }
    }
}