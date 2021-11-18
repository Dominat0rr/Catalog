using Catalog.DTO;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog {
    public static class Extensions {
        public static ItemDTO asDTO(this Item item) {
            return new ItemDTO {
                id = item.id,
                name = item.name,
                price = item.price,
                created = item.created
            };
        }
    }
}
