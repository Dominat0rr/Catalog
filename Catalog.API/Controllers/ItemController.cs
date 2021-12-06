using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers {
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase {
        private readonly IItemRepository repository;
        private readonly ILogger<ItemController> logger;

        public ItemController(IItemRepository repository, ILogger<ItemController> logger) {
            this.repository = repository;
            this.logger = logger;
        }

        // GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> getItemsAsync(string name = null) {
            //var items = repository.getItems().Select(item => item.asDTO());
            var items = (await repository.getItemsAsync())
                .Select(item => item.asDTO());

            if (!string.IsNullOrWhiteSpace(name))
                items = items.Where(item => item.name.Contains(name, StringComparison.OrdinalIgnoreCase));

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {items}");

            return items;
        }

        // GET /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> getItemAsync(Guid id) {
            //var item = repository.getItem(id);
            var item = await repository.getItemAsync(id);

            if (item is null)
                return NotFound();

            return item.asDTO();
        }

        // POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> addItemAsync(CreateItemDto itemDto) {
            Item item = new() {
                id = Guid.NewGuid(),
                name = itemDto.name,
                description = itemDto.description,
                price = itemDto.price,
                created = DateTimeOffset.UtcNow
            };

            await repository.createAsync(item);

            return CreatedAtAction(nameof(getItemAsync), new { id = item.id }, item.asDTO());
        }

        // PUT /items/id
        [HttpPut("{id}")]
        public async Task<ActionResult> updateItemAsync(Guid id, UpdateItemDto itemDto) {
            var existingItem = await repository.getItemAsync(id);

            if (existingItem is null)
                return NotFound();

            existingItem.name = itemDto.name;
            existingItem.description = itemDto.description;
            existingItem.price = itemDto.price;

            await repository.updateAsync(existingItem);

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
