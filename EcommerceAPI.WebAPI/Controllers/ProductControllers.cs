using EcommerceAPI.Application.Products.Dtos;
using EcommerceAPI.Application.Products.Queries.GetProductById;
using EcommerceAPI.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace EcommerceAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
                return NotFound($"No Product found for Id: {id}");

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

    }
}
