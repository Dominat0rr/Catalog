using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API {
    public record ItemDto(Guid id, string name, string description, decimal price, DateTimeOffset created);
    public record CreateItemDto([Required]string name, string description, [Range(1, 1000)]decimal price);
    public record UpdateItemDto([Required] string name, string description, [Range(1, 1000)] decimal price);
}
