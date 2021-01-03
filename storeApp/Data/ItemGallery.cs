using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeApp.Data
{
    public class ItemGallery
    { 
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
