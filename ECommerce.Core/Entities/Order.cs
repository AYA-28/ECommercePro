using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<OrderItem> Items { get; set; }
    }
}
