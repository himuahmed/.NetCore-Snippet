using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace storeApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Item  name please.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Item type please.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Enter Item price please.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Enter Item detail please.")]
        public string Detail { get; set; }
        [Required]
        public int OutletId { get; set; }

        public string OutletName { get; set; }

    }
}
