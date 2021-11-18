using Catalog.API.DTO;
using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API {
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
