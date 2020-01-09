﻿// <auto-generated />
using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ztm.Data.Entity.Postgres;

namespace Ztm.Data.Entity.Postgres.Migrations
{
    [DbContext(typeof(MainDatabase))]
    [Migration("20190531140853_SupportMtp")]
    partial class SupportMtp
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

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<byte[]>("MerkleRoot")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<byte[]>("MtpHashValue")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<int?>("MtpVersion");

                    b.Property<long>("Nonce");

                    b.Property<byte[]>("Reserved1")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<byte[]>("Reserved2")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<DateTime>("Time");

                    b.Property<int>("Version");

                    b.HasKey("Height");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.BlockTransaction", b =>
                {
                    b.Property<byte[]>("BlockHash")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<byte[]>("TransactionHash")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<int>("Index");

                    b.HasKey("BlockHash", "TransactionHash", "Index");

                    b.HasIndex("TransactionHash");

                    b.ToTable("BlockTransactions");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Input", b =>
                {
                    b.Property<byte[]>("TransactionHash")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<long>("Index");

                    b.Property<byte[]>("OutputHash")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

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
                    b.Property<byte[]>("TransactionHash")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<long>("Index");

                    b.Property<byte[]>("Script")
                        .IsRequired();

                    b.Property<long>("Value");

                    b.HasKey("TransactionHash", "Index");

                    b.ToTable("Outputs");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.Transaction", b =>
                {
                    b.Property<byte[]>("Hash")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

                    b.Property<long>("LockTime");

                    b.Property<long>("Version");

                    b.HasKey("Hash");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Ztm.Data.Entity.Contexts.Main.WebApiCallback", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<IPAddress>("RequestIp")
                        .IsRequired();

                    b.Property<DateTime>("RequestTime");

                    b.Property<byte[]>("TransactionId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 32)));

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
