using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Entities {
    // Record Types:
    // - Use for immutable objects
    // - With -expressions support
    // - Value-based equality support
    public class Item {
        // init:
        // - Init-only properties (only can be set during initialization)
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTimeOffset created { get; set; }


    }
}
