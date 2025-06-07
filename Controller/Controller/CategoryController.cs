using Microsoft.AspNetCore.Mvc;

namespace Controller.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            // Simulate fetching categories from a repository
            var categories = new List<string> { "Electronics", "Books", "Clothing" };
            return Ok(categories);
        }
    }
}
