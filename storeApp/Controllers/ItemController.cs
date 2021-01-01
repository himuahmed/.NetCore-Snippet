using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using storeApp.Models;
using storeApp.Repository;

namespace storeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemRepository _itemRepository = null;
        private readonly OutletRepository _outletRepository = null;
        private readonly IWebHostEnvironment _iWebHostEnvironment = null;

        public ItemController(ItemRepository itemRepository, OutletRepository outletRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _itemRepository = itemRepository;
            _outletRepository = outletRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
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
            
            if (ModelState.IsValid)
            {
                if (item.Photo != null)
                {
                    string folder = "Images/ItemPhoto";
                    folder += Guid.NewGuid().ToString() + "=" + item.Photo.FileName;
                    string serverPath = Path.Combine(_iWebHostEnvironment.WebRootPath, folder);

                    await item.Photo.CopyToAsync(new FileStream(serverPath, FileMode.Create));
                }

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
