using Ecommerce.API.Models.DTOs.Category;
using Ecommerce.API.Models.DTOs.Product;
using Ecommerce.API.Models.Entities;
using Ecommerce.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();

            var dto = new List<CategoryReadDto>();
            foreach (var category in categories)
            {
                dto.Add(new CategoryReadDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description

                });
            }
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
       
            };
            var createdProduct = await _categoryRepo.CreateAsync(category);

            return Ok();

        }



    }
}
