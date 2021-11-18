using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories {
    public interface IItemRepository {
        Item getItem(Guid id);
        Task<Item> getItemAsync(Guid id);
        IEnumerable<Item> getItems();
        Task<IEnumerable<Item>> getItemsAsync();
        void create(Item item);
        Task createAsync(Item item);
        void update(Item item);
        Task updateAsync(Item item);
        void delete(Guid id);
        Task deleteAsync(Guid id);
    }
}