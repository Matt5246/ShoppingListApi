using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_net_web_api.Data;
using asp_net_web_api.Services.SchoppingListService;

namespace asp_net_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ShoppingList>>> GetAll()
        {
            return await _shoppingListService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> Details(int id)
        {
            var result = await _shoppingListService.Details(id);
            if (result is null)
            {
                return NotFound("Product not found.");
            }
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<List<ShoppingList>>> AddProduct(ShoppingList product)
        {
            var result = await _shoppingListService.AddProduct(product);
            return Ok(result);
        }
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult<List<ShoppingList>>> Edit(int id, ShoppingList request)
        {
            var result = await _shoppingListService.Edit(id, request);
            if (result is null)
            {
                return NotFound("Product not found.");
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<ShoppingList>>> DeleteProduct(int id)
        {
            var result = await _shoppingListService.DeleteProduct(id);
            if (result is null)
            {
                return NotFound("Product not found.");
            }
            return Ok(result);
        }

    }
}
