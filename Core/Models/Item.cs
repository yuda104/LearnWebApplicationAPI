using Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public record Item
    {
        [Key]
        public Guid Id { get; init; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public static decimal SumAStatic(List<decimal> ListToSum)
        {
            return ListToSum.Sum();
        }

        public static ItemDto AsDto2(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                CreatedDate = item.CreatedDate,
                Price = item.Price
            };
        }
    }
}
