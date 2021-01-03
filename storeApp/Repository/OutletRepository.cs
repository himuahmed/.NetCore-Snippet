using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storeApp.Data;
using storeApp.Models;

namespace storeApp.Repository
{
    public class OutletRepository : IOutletRepository
    {
        private readonly ItemContext _itemContext = null;

        public OutletRepository(ItemContext itemContext)
        {
            _itemContext = itemContext;
        }

        public async Task<List<OutletModel>> GetAllOutlet()
        {
            var data = await _itemContext.Outlets.Select(x => new OutletModel()
            {
                Id =x.Id,
                Name = x.Name,
                Location = x.Location,
            }).ToListAsync();

            return data;
        }
    }
}
