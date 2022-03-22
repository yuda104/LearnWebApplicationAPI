using Core.Dtos;
using Core.Extension;
using Core.Models;
using Core.Request;
using Core.Response;
using DataStore.EF;
using DataStore.EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        [HttpGet(ApiRoutes.Items.GetAll)]
        public IActionResult GetItems()
        {
            var items = _itemRepository.GetItems();

            return Ok(items);
        }

        [HttpGet(ApiRoutes.Items.Get)]
        public IActionResult GetItem([FromRoute] Guid Id)
        {
            var item = _itemRepository.GetItem(Id);
            if (item == null)
                return NotFound();

            item.AsDto();

            return Ok(item);
        }

        [HttpPost(ApiRoutes.Items.Create)]
        public IActionResult Create([FromBody] CreateItemRequest itemDto)
        {
            Item item = new() {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };
            _itemRepository.CreateItem(item);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Items.Get.Replace("{Id}", item.Id.ToString());

            var response = new ItemResponse { Id = item.Id, CreatedDate = item.CreatedDate, Name = item.Name, Price = item.Price };

            //return Created(locationUrl, response);
            return CreatedAtAction(nameof(GetItem),
                   new { id = response.Id },
                   response
               );
        }

        [HttpPut(ApiRoutes.Items.Update)]
        public IActionResult UpdateItem([FromRoute] Guid Id, UpdateItemRequest updateItemRequest)
        {
            var item = new Item { Name = updateItemRequest.Name, Price = updateItemRequest.Price, Id = Id };

            var updated = _itemRepository.UpdateItem(item);

            if (updated)
                return Ok(updated);
            
            return NotFound(updated);
        }

        [HttpDelete(ApiRoutes.Items.Delete)]
        public IActionResult DeleteItem([FromRoute] Guid Id)
        {
            var deleted = _itemRepository.DeleteItem(Id);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
