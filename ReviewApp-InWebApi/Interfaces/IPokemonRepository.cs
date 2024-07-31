using ReviewApp_InWebApi.Dto;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        bool CreatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool UpdatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();
    }
}
