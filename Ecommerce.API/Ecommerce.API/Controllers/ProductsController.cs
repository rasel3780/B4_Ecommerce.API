using Ecommerce.API.Data;
using Ecommerce.API.Models.DTOs.Category;
using Ecommerce.API.Models.DTOs.Product;
using Ecommerce.API.Models.Entities;
using Ecommerce.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //localhost/api/product/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var dto = new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt ?? product.CreatedAt
            };

            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();

            var productDto = new List<ProductReadDto>();
            foreach (var product in products)
            {
                productDto.Add(new ProductReadDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt ?? product.CreatedAt,
                    StockQuantity = product.StockQuantity,
                    
                });
            }
            return Ok(productDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductWriteDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                ImageUrl = productDto.ImageUrl,
                CreatedAt = DateTime.Now,
            };
            
            

            var createdProduct = await _productRepo.CreateAsync(product);

            return Ok();
           
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductWriteDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                ImageUrl = productDto.ImageUrl
            };

            var updatedProduct = await _productRepo.Update(id, product);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _productRepo.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(new {Message = "deleted" });
        }

    }
}
