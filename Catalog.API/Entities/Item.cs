using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Entities {
    // Record Types:
    // - Use for immutable objects
    // - With -expressions support
    // - Value-based equality support
    public record Item {
        // init:
        // - Init-only properties (only can be set during initialization)
        public Guid id { get; init; }
        public string name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset created { get; init; }


    }
}
