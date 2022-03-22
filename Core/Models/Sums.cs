using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Sums
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
        public Sums()
        {

        }

        public static decimal SumAStatic(List<decimal> ListToSum)
        {
            return ListToSum.Sum();
        }
    }
}
