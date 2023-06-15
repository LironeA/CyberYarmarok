using Microsoft.EntityFrameworkCore;

namespace CyberYarmarok.Models
{
    public class CyberYarmarokContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Fair> Fairs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public CyberYarmarokContext(DbContextOptions<CyberYarmarokContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Account
            modelBuilder.Entity<Account>()
                        .HasMany(e => e.Fairs)
                        .WithOne(e => e.Account)
                        .HasForeignKey(e => e.AccountId)
                        .OnDelete(DeleteBehavior.NoAction);

            //Bid
            modelBuilder.Entity<Bid>();

            //Fair
            modelBuilder.Entity<Fair>()
                        .HasMany(e => e.Items)
                        .WithOne(e => e.Fair)
                        .HasForeignKey(e => e.FairId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Fair>()
                        .HasMany(e => e.Items)
                        .WithOne(e => e.Fair)
                        .HasForeignKey(e => e.FairId)
                        .OnDelete(DeleteBehavior.NoAction);

            //Item
            modelBuilder.Entity<Item>()
                        .HasMany(e => e.Bids)
                        .WithOne(e => e.Item)
                        .HasForeignKey(e => e.ItemId)
                        .OnDelete(DeleteBehavior.NoAction);

            //Order
            modelBuilder.Entity<Order>()
                        .HasOne(e => e.Item)
                        .WithOne(e => e.Order)
                        .HasForeignKey<Order>(e => e.ItemId)
                        .OnDelete(DeleteBehavior.NoAction);

            //Profile
            modelBuilder.Entity<Profile>()
                        .HasMany(e => e.Bids)
                        .WithOne(e => e.Profile)
                        .HasForeignKey(e => e.ProfileId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Profile>()
                        .HasMany(e => e.Orders)
                        .WithOne(e => e.Profile)
                        .HasForeignKey(e => e.ProfileId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Profile>()
                        .HasMany(e => e.Items)
                        .WithOne(e => e.Author)
                        .HasForeignKey(e => e.AuthorId)
                        .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
