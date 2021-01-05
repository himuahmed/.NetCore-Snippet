using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using storeApp.Models;

namespace storeApp.Data
{
    public class ItemContext : IdentityDbContext<ApplicationUser>
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
            
        }
        public  DbSet<Items> Items { get; set; }
        public  DbSet<Outlet> Outlets { get; set; }
        public  DbSet<ItemGallery> ItemGallery { get; set; }
        public  DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
