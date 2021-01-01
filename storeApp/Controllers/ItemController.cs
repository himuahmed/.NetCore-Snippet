using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using storeApp.Models;
using storeApp.Repository;

namespace storeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemRepository _itemRepository = null;
        private readonly OutletRepository _outletRepository = null;

        public ItemController(ItemRepository itemRepository, OutletRepository outletRepository)
        {
            _itemRepository = itemRepository;
            _outletRepository = outletRepository;
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

        public async Task<ViewResult> AddItem(bool isSuccess = false, int itemId = 0)
        {

            var outlets = await _outletRepository.GetAllOutlet();
            ViewBag.outlets = new SelectList(outlets, "Id","Name");

            ViewBag.isSuccess = isSuccess;
            ViewBag.itemId = itemId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            var outlets = await _outletRepository.GetAllOutlet();
            ViewBag.outlets = new SelectList(outlets, "Id", "Name");
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
