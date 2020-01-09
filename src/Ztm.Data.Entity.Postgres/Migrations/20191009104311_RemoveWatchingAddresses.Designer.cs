﻿// <auto-generated />
using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBitcoin;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ztm.Data.Entity.Postgres;

namespace Ztm.Data.Entity.Postgres.Migrations
{
    [DbContext(typeof(MainDatabase))]
    [Migration("20191009104311_RemoveWatchingAddresses")]
    partial class RemoveWatchingAddresses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Block", b =>
                {
                    b.Property<int>("Height");

                    b.Property<long>("Bits");

                    b.Property<uint256>("Hash")
                        .IsRequired();

                    b.Property<uint256>("MerkleRoot")
                        .IsRequired();

                    b.Property<uint256>("MtpHashValue");

                    b.Property<int?>("MtpVersion");

                    b.Property<long>("Nonce");

                    b.Property<uint256>("Reserved1");

                    b.Property<uint256>("Reserved2");

                    b.Property<DateTime>("Time");

                    b.Property<int>("Version");

                    b.HasKey("Height");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.BlockTransaction", b =>
                {
                    b.Property<uint256>("BlockHash");

                    b.Property<uint256>("TransactionHash");

                    b.Property<int>("Index");

                    b.HasKey("BlockHash", "TransactionHash", "Index");

                    b.HasIndex("TransactionHash");

                    b.ToTable("BlockTransactions");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Input", b =>
                {
                    b.Property<uint256>("TransactionHash");

                    b.Property<long>("Index");

                    b.Property<uint256>("OutputHash")
                        .IsRequired();

                    b.Property<long>("OutputIndex");

                    b.Property<byte[]>("Script")
                        .IsRequired();

                    b.Property<long>("Sequence");

                    b.HasKey("TransactionHash", "Index");

                    b.HasIndex("OutputHash", "OutputIndex");

                    b.ToTable("Inputs");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Output", b =>
                {
                    b.Property<uint256>("TransactionHash");

                    b.Property<long>("Index");

                    b.Property<byte[]>("Script")
                        .IsRequired();

                    b.Property<long>("Value");

                    b.HasKey("TransactionHash", "Index");

                    b.ToTable("Outputs");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Transaction", b =>
                {
                    b.Property<uint256>("Hash");

                    b.Property<long>("LockTime");

                    b.Property<long>("Version");

                    b.HasKey("Hash");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.WatchingBlock", b =>
                {
                    b.Property<uint256>("Hash");

                    b.Property<Guid>("Listener");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Hash", "Listener");

                    b.ToTable("WatchingBlocks");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.WatchingTransaction", b =>
                {
                    b.Property<uint256>("Hash");

                    b.Property<Guid>("Listener");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Hash", "Listener");

                    b.ToTable("WatchingTransactions");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.WebApiCallback", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<IPAddress>("RequestIp")
                        .IsRequired();

                    b.Property<DateTime>("RequestTime");

                    b.Property<uint256>("TransactionId");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("WebApiCallbacks");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.BlockTransaction", b =>
                {
                    b.HasOne("Ztm.Data.Entity.Contexts.Main.Block", "Block")
                        .WithMany("Transactions")
                        .HasForeignKey("BlockHash")
                        .HasPrincipalKey("Hash")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ztm.Data.Entity.Contexts.Main.Transaction", "Transaction")
                        .WithMany("Blocks")
                        .HasForeignKey("TransactionHash")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Input", b =>
                {
                    b.HasOne("Ztm.Data.Entity.Contexts.Main.Transaction", "Transaction")
                        .WithMany("Inputs")
                        .HasForeignKey("TransactionHash")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Output", b =>
                {
                    b.HasOne("Ztm.Data.Entity.Contexts.Main.Transaction", "Transaction")
                        .WithMany("Outputs")
                        .HasForeignKey("TransactionHash")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
