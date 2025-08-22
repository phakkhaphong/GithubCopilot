using System.Collections.Generic;
using System.Linq;

namespace Lab06.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }

        // Method to calculate total sales
        public static decimal CalculateTotalSales(List<Order> orders)
        {
            return orders?.Sum(o => o.Amount) ?? 0;
        }
    }
}
