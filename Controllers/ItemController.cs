using Catalog.DTO;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers {
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase {
        private readonly IItemRepository repository;

        public ItemController(IItemRepository repository) {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> getItemsAsync() {
            //var items = repository.getItems().Select(item => item.asDTO());
            var items = (await repository.getItemsAsync())
                .Select(item => item.asDTO());
            return items;
        }

        // GET /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> getItemAsync(Guid id) {
            //var item = repository.getItem(id);
            var item = await repository.getItemAsync(id);

            if (item is null)
                return NotFound();

            return item.asDTO();
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> addItemAsync(CreateItemDTO itemDto) {
            Item item = new() {
                id = Guid.NewGuid(),
                name = itemDto.name,
                price = itemDto.price,
                created = DateTimeOffset.UtcNow
            };

            await repository.createAsync(item);

            return CreatedAtAction(nameof(getItemAsync), new { id = item.id }, item.asDTO());
        }

        // PUT /items/id
        [HttpPut("{id}")]
        public async Task<ActionResult> updateItemAsync(Guid id, UpdateItemDTO itemDto) {
            var existingItem = await repository.getItemAsync(id);

            if (existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with {
                name = itemDto.name,
                price = itemDto.price
            };

            await repository.updateAsync(updatedItem);

            return NoContent();
        }

        // DELETE /items/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteItemAsync(Guid id) {
            var existingItem = await repository.getItemAsync(id);

            if (existingItem is null)
                return NotFound();

            await repository.deleteAsync(id);

            return NoContent();
        }
    }
}
