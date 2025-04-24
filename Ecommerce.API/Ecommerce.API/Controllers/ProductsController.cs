using Ecommerce.API.Data;
using Ecommerce.API.Models.DTOs.Product;
using Ecommerce.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }

        //localhost/api/product/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //var product = _context.Products.Find(id);
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();

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
                    StockQuantity = product.StockQuantity
                });
            }
            return Ok(productDto);
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productDto)
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
            
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);

            
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductUpdateDto productDto)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id==id);
            if(product == null)
            {
                return NotFound();
            }
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.StockQuantity = productDto.StockQuantity;
            product.ImageUrl = productDto.ImageUrl;
            product.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return Ok(productDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id==id);
            if (product==null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }

    }
}
