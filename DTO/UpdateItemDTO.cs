using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.DTO {
    public class UpdateItemDTO {
        [Required]
        public string name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal price { get; init; }
    }
}
