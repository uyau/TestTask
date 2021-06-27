using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers.Models;

namespace WebApplication.Servises
{
    public static class OrderService
    {
        static List<Order> Orders { get; }
        static int nextId = 1;
        static OrderService()
        {
            Orders = new List<Order> { };
        }

        public static List<Order> GetAll() => Orders;

        public static Order Get(int id) => Orders.FirstOrDefault(o => o.Id == id);

        public static void Add(Order order)
        {
            order.Id = nextId++;
            Orders.Add(order);
        }

        public static void Delete(int id)
        {
            var order = Get(id);
            if (order is null)
                return;

            Orders.Remove(order);
        }

        public static void Update(Order order)
        {
            var index = Orders.FindIndex(o => o.Id == order.Id);
            if (index == -1)
                return;

            Orders[index] = order;
        }
    }
}
