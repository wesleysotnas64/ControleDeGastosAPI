using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.CategoryDTO;
using ControleDeGastosAPI.Entities;

namespace ControleDeGastosAPI.Services
{
    public class CategoryService
    {
        private readonly ContextAPI _context;

        public CategoryService(ContextAPI context)
        {
            _context = context;
        }

        public async Task<CategoryResponseDTO> CreateCategoryAsync(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category
            {
                Description = categoryCreateDTO.Description,
                Purpose = categoryCreateDTO.Purpose,
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryResponseDTO
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }
    }
}
