﻿// <auto-generated />
using System;
using MTP.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MTP.Migrations
{
    [DbContext(typeof(MoneyTrackerDataContext))]
    partial class MoneyTrackerDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("MTP.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid>("ProfileId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("AccountId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MTP.Entities.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FilterCategory");

                    b.Property<string>("FilterMonth");

                    b.Property<string>("FilterYear");

                    b.Property<string>("PIN");

                    b.Property<string>("Title");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("MTP.Entities.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<float>("Amount");

                    b.Property<string>("Category");

                    b.Property<bool>("IsIncome");

                    b.Property<string>("Note");

                    b.Property<bool>("Processed");

                    b.Property<string>("Title");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<bool>("_IsIncome");

                    b.Property<bool>("_Processed");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MTP.Entities.Account", b =>
                {
                    b.HasOne("MTP.Entities.Profile", "Profile")
                        .WithMany("Accounts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MTP.Entities.Transaction", b =>
                {
                    b.HasOne("MTP.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
