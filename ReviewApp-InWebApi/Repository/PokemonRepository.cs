﻿using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context=context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault(); 
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if( review.Count() <=0) 
            { 
                return 0;
            }
            return ((decimal)review.Sum(r=>r.Rating)/review.Count());
        }

        public  ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p=>p.Id).ToList(); 
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p=>p.Id == pokeId);
            
        }
    }
}
