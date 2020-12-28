using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeApp.Models;
using storeApp.Repository;

namespace storeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemRepository _itemRepository = null;

        public ItemController()
        {
            _itemRepository = new ItemRepository();
        }
        public ViewResult GetAllItems()
        {
            var data =  _itemRepository.GetAllItems();

            return View(data);
        }

        public ViewResult GetItem(int id)
        {
            var data =  _itemRepository.GetItem(id);
            return View(data);
        }

        public List<Item> SearchItem(string Name)
        {
            return _itemRepository.SearchItem(Name);
        }
    }
}
