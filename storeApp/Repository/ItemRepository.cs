using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeApp.Models;

namespace storeApp.Repository
{
    public class ItemRepository
    {
        private List<Item> Items()
        {
            return new List<Item>()
            {
                new Item() {Id = 1, Name = "Coke", Type = "Grocery"},
                new Item() {Id = 2, Name = "Chips", Type = "Grocery"},
                new Item() {Id = 3, Name = "Cake", Type = "Grocery"},
                new Item() {Id = 4, Name = "Eggs", Type = "Food"}
            };
        }

        public List<Item> GetAllItems()
        {
            return Items();
        }

        public Item GetItem(int Id)
        {
            return Items().FirstOrDefault(x => x.Id == Id);
        }

        public List<Item> SearchItem(string Name)
        {
            return Items().Where(x => x.Name == Name).ToList();
        }
    }
}
