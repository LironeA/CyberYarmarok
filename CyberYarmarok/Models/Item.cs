namespace CyberYarmarok.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int StartPrice { get; set; }
        public int MinimalStep { get; set; }

        public int AuthorId { get; set; }
        public virtual Profile Author { get; set; }

        public int FairId { get; set; }
        public virtual Fair Fair { get; set; }

        public virtual ICollection<Bid>? Bids { get; set; }

        public virtual Order? Order { get; set; }

        public Item() { }

    }
}
