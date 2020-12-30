using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddItem(Item item)
        {
            var newItem = new Items()
            {
                Name = item.Name,
                Type = item.Type,
                Detail = item.Detail,
                Price = item.Price
            };

           await _context.Items.AddAsync(newItem);
           await _context.SaveChangesAsync();

            return newItem.Id;
        }

        public async Task<List<Item>> GetAllItems()
        {
            var newItem = new List<Item>();
            var items = await _context.Items.ToListAsync();
            if (items?.Any() == true)
            {
                foreach(var item in items)
                {
                    newItem.Add(new Item()
                    {
                        Name = item.Name,
                        Type = item.Type,
                        Price = item.Price,
                        Id = item.Id,
                        Detail = item.Detail
                    });
                }
            }

            return newItem;
        }

        public async Task<Items> GetItem(int id)
        {
            
            var newItem = await _context.Items.FindAsync(id);
            //return Items().FirstOrDefault(x => x.Id == id);
            if (newItem != null)
            {
                var data = new Items()
                {
                    Id = newItem.Id,
                    Name = newItem.Name,
                    Type = newItem.Type,
                    Price = newItem.Price,
                    Detail = newItem.Detail
                };

                return data;
            }

            return null;
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
