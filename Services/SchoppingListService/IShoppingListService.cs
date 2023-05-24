using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_web_api.Services.SchoppingListService
{
    public interface IShoppingListService
    {
        Task<List<ShoppingList>> GetAll();
        Task<ShoppingList?> Details(int id);
        Task<List<ShoppingList>> AddProduct(ShoppingList product);
        Task<List<ShoppingList>?> Edit(int id, ShoppingList request);
        Task<List<ShoppingList>?> DeleteProduct(int id);
    }
}