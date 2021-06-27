using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers.Models;
using WebApplication.Servises;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Order>> Get() => OrderService.GetAll();
        

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = OrderService.Get(id);
            if (order is null)
                return NotFound();

            return order;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var items = ItemService.GetAll();
            var itemExist = order.ItemsIds.Except(items.ToList().Select(x => x.Id));
            if (itemExist.Any())
                return NotFound();
            OrderService.Add(order);

            return CreatedAtAction(nameof(Create), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            var proofItemExist = OrderService.Get(id);
            if (proofItemExist is null)
                return BadRequest();

            var items = ItemService.GetAll();
            var itemExist = order.ItemsIds.Except(items.ToList().Select(x => x.Id));
            if (itemExist.Any())
                return NotFound();
            OrderService.Update(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = OrderService.Get(id);
            if (order is null)
                return NotFound();
            OrderService.Delete(id);

            return NoContent();
        }
    }
}
