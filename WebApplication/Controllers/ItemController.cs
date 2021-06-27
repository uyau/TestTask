using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers.Models;
using WebApplication.Servises;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Item>> GetAll() => ItemService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = ItemService.Get(id);
            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            ItemService.Add(item);

            return CreatedAtAction(nameof(Create), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id, Item item)
        {
            if (id != item.Id)
                return BadRequest();

            var proofItemExist = ItemService.Get(id);
            if (proofItemExist is null)
                return BadRequest();
            ItemService.Update(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var item = ItemService.Get(id);
            if (item is null)
                return NotFound();
            ItemService.Delete(id);

            return NoContent();
        }
    }
}
