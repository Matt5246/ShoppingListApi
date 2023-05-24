using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asp_net_web_api.Services.SchoppingListService
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly ShoppingDbContext _context;
        public ShoppingListService(ShoppingDbContext context)
        {
            _context = context;
        }
        public async Task<List<ShoppingList>> AddProduct(ShoppingList product)
        {
            _context.ShoppingLists.Add(product);
            await _context.SaveChangesAsync();
            return await _context.ShoppingLists.ToListAsync();
        }
        public async Task<List<ShoppingList>?> DeleteProduct(int id)
        {
            var product = await _context.ShoppingLists.FindAsync(id);
            if (product is null)
            {
                return null;
            }

            _context.ShoppingLists.Remove(product);
            await _context.SaveChangesAsync();
            return await _context.ShoppingLists.ToListAsync();
        }
        public async Task<List<ShoppingList>?> Edit(int id, ShoppingList request)
        {
            var product = await _context.ShoppingLists.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            product.Title = request.Title;
            product.Description = request.Description;
            product.kcal = request.kcal;

            await _context.SaveChangesAsync();

            return await _context.ShoppingLists.ToListAsync();
        }
        public async Task<ShoppingList?> Details(int id)
        {
            var product = await _context.ShoppingLists.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            return product;
        }
        public async Task<List<ShoppingList>> GetAll()
        {
            var shoppingLists = await _context.ShoppingLists.ToListAsync();
            return shoppingLists;
        }
    }
}