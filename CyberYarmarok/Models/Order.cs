using System.Runtime.InteropServices;

namespace CyberYarmarok.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }

        public int Price { get; set; }
        public bool IsPaid { get; set; }

        public Order() { }
    }
}
