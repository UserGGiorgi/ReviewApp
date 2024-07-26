using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ReviewApp_InWebApi.Dto;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;
namespace ReviewApp_InWebApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository,IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200,Type =typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if(!_pokemonRepository.PokemonExists(pokeId))
            {
                return BadRequest(ModelState);
            }
            var pokemon= _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return BadRequest(ModelState);
            }
            var rating=_pokemonRepository.GetPokemonRating(pokeId);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rating);
        }
    }
}
