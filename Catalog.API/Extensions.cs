using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API {
    public static class Extensions {
        public static ItemDto asDTO(this Item item) {
            return new ItemDto(
                item.id, 
                item.name, 
                item.description, 
                item.price, 
                item.created
            );
        }
    }
}
