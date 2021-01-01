using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeApp.Data
{
    public class Outlet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Items> Items { get; set; }
    }
}
