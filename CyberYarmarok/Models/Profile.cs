namespace CyberYarmarok.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telegram { get; set; }
        public string StudentId { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Bid>? Bids { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
    }
}
