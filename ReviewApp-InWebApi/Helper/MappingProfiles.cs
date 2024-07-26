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
        }
    }
}
