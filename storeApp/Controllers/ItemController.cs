﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using storeApp.Models;
using storeApp.Repository;

namespace storeApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository = null;
        private readonly IOutletRepository _outletRepository = null;
        private readonly IWebHostEnvironment _iWebHostEnvironment = null;

        public ItemController(IItemRepository itemRepository, IOutletRepository outletRepository, IWebHostEnvironment iWebHostEnvironment)
        {
            _itemRepository = itemRepository;
            _outletRepository = outletRepository;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        [Route("Items")]
        public async Task<ViewResult>  GetAllItems()
        {
            var data = await _itemRepository.GetAllItems();

            return View(data);
        }

        [Route("search-item/{id}")]
        public async Task<ViewResult> GetItem(int id)
        {
            var data = await _itemRepository.GetItem(id);
            return View(data);
        }

        public List<Item> SearchItem(string Name)
        {
            return _itemRepository.SearchItem(Name);
        }

        [Authorize]
        [Route("Add-Item")]
        public async Task<ViewResult> AddItem(bool isSuccess = false, int itemId = 0)
        {

            var outlets = await _outletRepository.GetAllOutlet();
            //ViewBag.outlets = new SelectList(outlets, "Id","Name");

            ViewBag.isSuccess = isSuccess;
            ViewBag.itemId = itemId;
            return View();
        }

        
        [HttpPost]
        [Route("Add-Item")]
        public async Task<IActionResult> AddItem(Item item)
        {
            
            if (ModelState.IsValid)
            {
                if (item.Photo != null)
                {
                    string folder = "Images/ItemPhoto/";
                    item.PhotoUrl= await ImageUpload(folder, item.Photo);
                }

                item.Gallery = new List<ImageGallery>();

                if (item.Images != null)
                {
                    string folderGallery = "Images/Gallery/";
                    
                    foreach (var file in item.Images)
                    {
                        var gallery = new ImageGallery()
                        {
                            Name = file.FileName,
                            Url = await ImageUpload(folderGallery, file),
                        };

                        item.Gallery.Add(gallery);
                    };
                        
                }
                 
                int id = await _itemRepository.AddItem(item);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddItem), new { isSuccess = true, itemId = id });
                }
            }
            return View();
        }

        private async Task<string> ImageUpload(string folder, IFormFile file)
        {
            
            folder += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverPath = Path.Combine(_iWebHostEnvironment.WebRootPath, folder);

            await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));

            return "/" + serverPath;
        }
    }
}
