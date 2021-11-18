using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories {
    public class MongoDBItemsRepository : IItemRepository {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDBItemsRepository(IMongoClient mongoClient) {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }

        public void create(Item item) {
            itemsCollection.InsertOne(item);
        }

        public void delete(Guid id) {
            var filter = filterBuilder.Eq(item => item.id, id);
            itemsCollection.DeleteOne(filter);
        }

        public Item getItem(Guid id) {
            var filter = filterBuilder.Eq(item => item.id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> getItems() {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void update(Item item) {
            var filter = filterBuilder.Eq(exitstingItem => exitstingItem.id, item.id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public async Task createAsync(Item item) {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task deleteAsync(Guid id) {
            var filter = filterBuilder.Eq(item => item.id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> getItemAsync(Guid id) {
            var filter = filterBuilder.Eq(item => item.id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> getItemsAsync() {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task updateAsync(Item item) {
            var filter = filterBuilder.Eq(exitstingItem => exitstingItem.id, item.id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}
