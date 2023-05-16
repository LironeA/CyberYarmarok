namespace CyberYarmarok.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile? Profile { get; set; }

        public DateTime? Created { get; set; }
        public int Price { get; set; }



        public Bid() { }

    }
}
