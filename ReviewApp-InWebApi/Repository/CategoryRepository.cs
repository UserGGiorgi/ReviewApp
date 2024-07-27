using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {//we need select statement for nested entities
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(c=>c.Pokemon).ToList();
        }
    }
}
