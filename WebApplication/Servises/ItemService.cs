using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers.Models;

namespace WebApplication.Servises
{
    public static class ItemService
    {
        static List<Item> Items { get; }
        static int nextId = 4;
        static ItemService()
        {
            Items = new List<Item>
            {
                new Item{Id = 1, Name = "Phone",Price = 5000},
                new Item{Id = 2, Name = "Camera",Price = 10000},
                new Item{Id = 3, Name = "Laptop",Price = 30000}
            };
        }

        public static List<Item> GetAll() => Items;

        public static Item Get(int id) => Items.FirstOrDefault(i => i.Id == id);

        public static void Add(Item item)
        {
            item.Id = nextId++;
            Items.Add(item);
        }

        public static void Delete(int id)
        {
            var item = Get(id);
            if (item is null)
                return;

            Items.Remove(item);
        }

        public static void Update(Item item)
        {
            var index = Items.FindIndex(i => i.Id == item.Id);
            if (index == -1)
                return;

            Items[index] = item;
        }
    }
}

