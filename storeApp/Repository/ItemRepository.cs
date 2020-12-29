using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeApp.Data;
using storeApp.Models;

namespace storeApp.Repository
{
    public class ItemRepository
    {
        private readonly ItemContext _context = null;

        public ItemRepository(ItemContext context)
        {
            _context = context;
        }

        public int AddItem(Item item)
        {
            var newItem = new Items()
            {
                Name = item.Name,
                Type = item.Type,
                Detail = item.Detail,
                Price = item.Price
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();

            return newItem.Id;
        }

        public List<Item> GetAllItems()
        {
            return Items();
        }

        public Item GetItem(int id)
        {
            return Items().FirstOrDefault(x => x.Id == id);
        }

        public List<Item> SearchItem(string Name)
        {
            return Items().Where(x => x.Name == Name).ToList();
        }


        private List<Item> Items()
        {
            return new List<Item>()
            {
                new Item() {Id = 1, Name = "Coke", Type = "Grocery"},
                new Item() {Id = 2, Name = "Chips", Type = "Grocery"},
                new Item() {Id = 3, Name = "Cake", Type = "Grocery"},
                new Item() {Id = 4, Name = "Eggs", Type = "Food"}
            };
        }

    }
}
