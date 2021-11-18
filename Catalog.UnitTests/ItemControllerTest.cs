using Catalog.API.Controllers;
using Catalog.API.DTO;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
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
            //Assert.IsType<NotFoundResult>(result.Result);
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
            result.Value.Should().BeEquivalentTo(
                expectedItem,
                options => options.ComparingByMembers<Item>()
                );

            //Assert.IsType<ItemDTO>(result.Value);
            //var dto = (result as ActionResult<ItemDTO>).Value;
            //Assert.Equal(expectedItem.id, dto.id);
            //Assert.Equal(expectedItem.name, dto.name);
            //Assert.Equal(expectedItem.price, dto.price);
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
            result.Should().BeEquivalentTo(
                expectedItems,
                options => options.ComparingByMembers<Item>()
                );
        }

        [Fact]
        public async Task addItemAsync_WithItemToCreate_ReturnsCreatedItem() {
            // Arrange
            var itemToCreate = new CreateItemDTO() {
                name = Guid.NewGuid().ToString(),
                price = rand.Next(1000)
            };

            var controller = new ItemController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.addItemAsync(itemToCreate);

            // Assert
            var createdItem = (result.Result as CreatedAtActionResult).Value as ItemDTO;
            itemToCreate.Should().BeEquivalentTo(
                createdItem,
                options => options.ComparingByMembers<ItemDTO>().ExcludingMissingMembers()
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
            var itemToUpdate = new UpdateItemDTO() {
                name = Guid.NewGuid().ToString(),
                price = existingItem.price + 3
            };

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
