using System.Collections.Generic;

namespace CyberYarmarok.Models
{
    public class Fair
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; } 

        public virtual ICollection<Item> Items { get; set; }

        public Fair() {}

    }
}
