using AutoMapper;
using ReviewApp_InWebApi.Dto;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon,PokemonDto>();
            CreateMap<PokemonDto,Pokemon>();
            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();
            CreateMap<Country,CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Owner, OwnerDto> ();
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
  