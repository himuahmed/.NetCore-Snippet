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

        public ItemController(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ViewResult>  GetAllItems()
        {
            var data = await _itemRepository.GetAllItems();

            return View(data);
        }

        public async Task<ViewResult> GetItem(int id)
        {
            var data = await _itemRepository.GetItem(id);
            return View(data);
        }

        public List<Item> SearchItem(string Name)
        {
            return _itemRepository.SearchItem(Name);
        }

        public ViewResult AddItem(bool isSuccess = false, int itemId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.itemId = itemId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                int id = await _itemRepository.AddItem(item);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddItem), new { isSuccess = true, itemId = id });
                }
            }
            return View();
        }

    }
}
