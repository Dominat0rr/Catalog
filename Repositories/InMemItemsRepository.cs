using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories {
    public class InMemItemsRepository : IItemRepository {
        private readonly List<Item> items = new() {
            new Item { id = Guid.NewGuid(), name = "Potion", price = 9, created = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), name = "Iron Sword", price = 20, created = DateTimeOffset.UtcNow },
            new Item { id = Guid.NewGuid(), name = "Bronze Shield", price = 18, created = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> getItems() {
            return items;
        }

        public Item getItem(Guid id) {
            return items.Where(item => item.id == id).FirstOrDefault();
        }

        public void create(Item item) {
            items.Add(item);
        }

        public void update(Item item) {
            var index = items.FindIndex(existingItem => existingItem.id == item.id);
            items[index] = item;
        }

        public void delete(Guid id) {
            var index = items.FindIndex(existingItem => existingItem.id == id);
            items.RemoveAt(index);
        }

        Task<Item> IItemRepository.getItemAsync(Guid id) {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> IItemRepository.getItemsAsync() {
            throw new NotImplementedException();
        }

        Task IItemRepository.createAsync(Item item) {
            throw new NotImplementedException();
        }

        Task IItemRepository.updateAsync(Item item) {
            throw new NotImplementedException();
        }

        Task IItemRepository.deleteAsync(Guid id) {
            throw new NotImplementedException();
        }
    }
}
