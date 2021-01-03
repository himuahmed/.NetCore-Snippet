using System.Collections.Generic;
using System.Threading.Tasks;
using storeApp.Models;

namespace storeApp.Repository
{
    public interface IItemRepository
    {
        Task<int> AddItem(Item item);
        Task<List<Item>> GetAllItems();
        Task<Item> GetItem(int id);
        List<Item> SearchItem(string Name);
    }
}