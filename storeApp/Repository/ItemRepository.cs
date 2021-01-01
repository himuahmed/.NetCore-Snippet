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
                Price = item.Price,
                OutletId = item.OutletId
            };

           await _context.Items.AddAsync(newItem);
           await _context.SaveChangesAsync();

            return newItem.Id;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.Select(item => new Item()
            {
                Name = item.Name,
                Type = item.Type,
                Price = item.Price,
                Id = item.Id,
                Detail = item.Detail,
                OutletId = item.OutletId,
                OutletName = item.Outlet.Name
            }).ToListAsync();

        }

        public async Task<Item> GetItem(int id)
        {


            return await _context.Items.Where(x => x.Id == id).Select(item => new Item()
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                Price = item.Price,
                Detail = item.Detail,
                OutletName = item.Outlet.Name
            }).FirstOrDefaultAsync();

        }

        public List<Item> SearchItem(string Name)
        {
            return null;
        }


    }
}
