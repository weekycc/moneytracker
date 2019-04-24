using Microsoft.EntityFrameworkCore;
using MTP.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MTP.Entities
{
    public class MoneyTrackerDataContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Category> Categorys { get; set; }
        private string databaseName = "database.db";
        public MoneyTrackerDataContext(string databasePath="database.db")
        {
            databaseName = databasePath;
#if DEBUG
#endif
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
            this.Database.Migrate();
            SeedData();
#if DEBUG
#endif
        }
        private void SeedData()
        {
            try
            {
                if (Profiles.Count() < 1)
                {
                    //Categorys.Add(new Category() { CategoryId = "Mortgage" });
                    //Categorys.Add(new Category() { CategoryId = "Rent" });
                    //Categorys.Add(new Category() { CategoryId = "Property Tax" });
                    //Categorys.Add(new Category() { CategoryId = "Fee" });
                    //Categorys.Add(new Category() { CategoryId = "House Insurance" });
                    //Categorys.Add(new Category() { CategoryId = "Utility Bill" });
                    //Categorys.Add(new Category() { CategoryId = "Lease" });
                    //Categorys.Add(new Category() { CategoryId = "Car Loan" });
                    //Categorys.Add(new Category() { CategoryId = "Car Insuarnce" });
                    //Categorys.Add(new Category() { CategoryId = "Life Insuarnce" });
                    //Categorys.Add(new Category() { CategoryId = "Bank Fee" });
                    Profiles.Add(new Profile() { ProfileId = Guid.NewGuid(), Title = "My Profile", FilterYear="Current", FilterMonth="Current", FilterCategory="All" });
                    SaveChanges();
                    Accounts.Add(new Account() { Profile = this.Profiles.First(), AccountId = Guid.NewGuid(), Title = "My Account", StartDate = DateTime.Now });
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    Accounts.Add(new Account() { Profile=this.Profiles.First(), AccountId = Guid.NewGuid(), Title = "test " + i, StartDate=DateTime.Now });
                    //}
                    //SaveChanges();
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    Transactions.Add(new Transaction() { Account = this.Accounts.First(), TransactionId = Guid.NewGuid(), Title = "test " + i, TransactionDate = DateTime.Now, Amount = 100 * i, Category = "Food" });
                    //    //Transactions.Add(new Transaction() {Account=this.Accounts.First(), TransactionId = Guid.NewGuid(), Title = "test " + i, TransactionDate=DateTime.Now, Amount=100*i, Category="Food", Type = -1 });
                    //}
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }
        //todo: need to work on db migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //migration generation: comment below line
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={databaseName}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications)
                .HasOne(p => p.Account)
                .WithMany(b => b.Transactions)
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(p => p.Category)
            //    .WithMany(b => b.Transactions)
            //    .HasForeignKey(p => p.CategoryId)
            //    .OnDelete(DeleteBehavior.SetNull)
            //    .IsRequired(false);

            modelBuilder.Entity<Account>()
                .HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications)
                .HasOne(p => p.Profile)
                .WithMany(b => b.Accounts)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Profile>()
                .HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
        }
        public virtual void UndoChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

    }
}
