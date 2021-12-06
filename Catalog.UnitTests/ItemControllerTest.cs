using Catalog.API;
using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests {
    // Cmd for running all tests:
    // dotnet test
    public class ItemControllerTest {
        private readonly Mock<IItemRepository> repositoryStub = new();
        private readonly Mock<ILogger<ItemController>> loggerStub = new();
        private readonly Random rand = new();

        private Item createRandomItem() {
            return new() {
                id = Guid.NewGuid(),
                name = Guid.NewGuid().ToString(),
                price = rand.Next(1000),
                created = DateTimeOffset.UtcNow
            };
        }

        [Fact]
        public async Task getItemAsync_WithUnexistingItem_ReturnsNotFound() {
            // Arrange
            repositoryStub.Setup(repo => repo.getItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.getItemAsync(Guid.NewGuid());

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task getItemAsync_WithExistingItem_ReturnsExpectedItem() {
            // Arrange
            var expectedItem = createRandomItem();

            repositoryStub.Setup(repo => repo.getItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedItem);

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.getItemAsync(Guid.NewGuid());

            // Assert
            result.Value.Should().BeEquivalentTo(expectedItem);
        }

        [Fact]
        public async Task getItemsAsync_WithExistingItems_ReturnsAllItems() {
            // Arrange
            var expectedItems = new[] { createRandomItem(), createRandomItem(), createRandomItem() };

            repositoryStub.Setup(repo => repo.getItemsAsync())
                .ReturnsAsync(expectedItems);

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.getItemsAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedItems);
        }

        [Fact]
        public async Task getItemsAsync_WithMatchingItems_ReturnsAllMatchingItems() {
            // Arrange
            var allItems = new[] { 
                new Item() { name = "Potion" },
                new Item() { name = "Antidote" },
                new Item() { name = "Medium Potion" },
                new Item() { name = "Large Potion" },
                new Item() { name = "Bronze Sword" },
                new Item() { name = "Iron Sword" },
                new Item() { name = "Golden Axe" },
            };

            var nameToMatch = "Potion";

            repositoryStub.Setup(repo => repo.getItemsAsync())
                .ReturnsAsync(allItems);

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            IEnumerable<ItemDto> foundItems = await controller.getItemsAsync(nameToMatch);

            // Assert
            foundItems.Should().OnlyContain(
                item => item.name == allItems[0].name || item.name == allItems[2].name || item.name == allItems[3].name
            );
        }

        [Fact]
        public async Task addItemAsync_WithItemToCreate_ReturnsCreatedItem() {
            // Arrange
            var itemToCreate = new CreateItemDto(
                Guid.NewGuid().ToString(), 
                Guid.NewGuid().ToString(), 
                rand.Next(1000)
            );

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.addItemAsync(itemToCreate);

            // Assert
            var createdItem = (result.Result as CreatedAtActionResult).Value as ItemDto;
            itemToCreate.Should().BeEquivalentTo(
                createdItem,
                options => options.ComparingByMembers<ItemDto>().ExcludingMissingMembers()
                );
            createdItem.id.Should().NotBeEmpty();
            createdItem.created.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMilliseconds(1000));
        }

        [Fact]
        public async Task updateItemAsync_WithExistingItem_ReturnsNoContent() {
            // Arrange
            Item existingItem = createRandomItem();

            repositoryStub.Setup(repo => repo.getItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var itemId = existingItem.id;
            var itemToUpdate = new UpdateItemDto(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                existingItem.price + 3
            );

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.updateItemAsync(itemId, itemToUpdate);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task deleteItemAsync_WithExistingItem_ReturnsNoContent() {
            // Arrange
            Item existingItem = createRandomItem();

            repositoryStub.Setup(repo => repo.getItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(existingItem);

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.deleteItemAsync(existingItem.id);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
