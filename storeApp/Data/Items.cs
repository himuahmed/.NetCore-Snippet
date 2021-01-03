using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace storeApp.Data
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Detail { get; set; }
        public int OutletId { get; set; }
        public string PhotoUrl { get; set; }
        public Outlet Outlet { get; set; }

        public ICollection<ItemGallery> ItemGallery { get; set; }
        
    }
}
