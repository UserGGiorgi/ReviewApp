using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        

        public OwnerRepository(DataContext context)
        {
            _context = context;
            
        }
        public Owner GetOwnerById(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p=>p.PokemonId==pokeId).Select(o=>o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
           return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p=>p.OwnerId==ownerId).Select(p=>p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o=>o.Id== ownerId);
        }
    }
}
