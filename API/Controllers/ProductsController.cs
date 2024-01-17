using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] // This attribute tells ASP.NET Core that this class is an API controller
    [Route("api/[controller]")] // This attribute tells ASP.NET Core that this controller is accessible via the /api/products route

    public class ProductsController : ControllerBase // This class inherits from ControllerBase, which is a base class for API controllers in ASP.NET Core
    {
        // This is a constructor for the ProductsController class. It takes a StoreContext object as a parameter.
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context; // The constructor assigns the StoreContext object to the context field

        }

        [HttpGet] // This attribute tells ASP.NET Core that this method is accessible via the HTTP GET verb
        public async Task<ActionResult<List<Product>>> GetProducts() // This method returns a list of Product objects
        {
            var products = await context.Products.ToListAsync(); // This line uses the context field to get all the products from the database and store them in the products variable
            return products; // This line returns the products variable
        }

        [HttpGet("{id}")] // This attribute tells ASP.NET Core that this method is accessible via the HTTP GET verb and that it accepts an id parameter
        public async Task<ActionResult<Product>> GetProduct(int id) // This method returns a Product object
        {
            var product = await context.Products.FindAsync(id); // This line uses the context field to get the product with the specified id from the database and store it in the product variable

            if (product == null) return NotFound(); // This line checks if the product variable is null. If it is, the method returns a 404 Not Found response

            return product; // This line returns the product variable
        }

    }
}