using Core.Dtos;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto {
                Id = item.Id,
                Name = item.Name,
                CreatedDate = item.CreatedDate,
                Price = item.Price
            };
        }
    }
}
