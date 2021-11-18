using System;

namespace Catalog.API.DTO {
    public record ItemDTO {
        public Guid id { get; init; }
        public string name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset created { get; init; }
    }
}
