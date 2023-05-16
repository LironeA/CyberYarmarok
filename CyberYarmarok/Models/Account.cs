using System.Collections.Generic;

namespace CyberYarmarok.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaymentDetails{ get; set; }
        public virtual ICollection<Fair>? Fairs { get; set; }

        public Account() { }
    }
}
