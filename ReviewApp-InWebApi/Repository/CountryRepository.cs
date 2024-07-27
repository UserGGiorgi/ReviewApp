using AutoMapper;
using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _Context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext Context,IMapper mapper)

        {
            _Context = Context;
            _mapper = mapper;
        }
        public bool CountryExists(int id)
        {
            return _Context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _Context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _Context.Countries.Where(c=>c.Id==id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _Context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _Context.Owners.Where(c => c.Id == countryId).ToList();
        }
    }
}
