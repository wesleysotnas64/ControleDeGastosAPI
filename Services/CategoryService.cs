using ControleDeGastosAPI.DBContext;
using ControleDeGastosAPI.DTOs.CategoryDTO;
using ControleDeGastosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastosAPI.Services
{
    public class CategoryService
    {
        private readonly ContextAPI _context;

        // injeção de dependência do ContextAPI para acessar o banco de dados
        public CategoryService(ContextAPI context)
        {
            _context = context;
        }

        public async Task<CategoryResponseDTO> CreateCategoryAsync(CategoryCreateDTO categoryCreateDTO)
        {

            if (categoryCreateDTO.Description == null) throw new Exception("A descrição da categoria é obrigatória.");
            if (categoryCreateDTO.Description.Length > 400) throw new Exception("A descrição da categoria deve conter no máximo 400 caracteres.");

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

        public async Task<List<CategoryResponseDTO>> GetAllCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories.Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Description = c.Description,
                Purpose = c.Purpose,
            }).ToList();
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryResponseDTO
            {
                Id = category.Id,
                Description = category.Description,
                Purpose = category.Purpose,
            };
        }
    }
}
