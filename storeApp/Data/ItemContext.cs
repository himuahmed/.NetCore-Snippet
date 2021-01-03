using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace storeApp.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
            
        }
        public  DbSet<Items> Items { get; set; }
        public  DbSet<Outlet> Outlets { get; set; }
        public  DbSet<ItemGallery> ItemGallery { get; set; }

    }
}
