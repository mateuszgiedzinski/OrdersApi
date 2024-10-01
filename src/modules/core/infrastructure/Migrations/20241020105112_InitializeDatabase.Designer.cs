﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagCoders.Orders.Modules.Core.Infrastructure.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20241020105112_InitializeDatabase")]
    partial class InitializeDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagCoders.Orders.Modules.Core.Domain.CustomerAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("BirthDate");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("CreditCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreditCard");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailAddress");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("Level");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "MagCoders.Orders.Modules.Core.Domain.CustomerAggregate.Name#CustomerName", b1 =>
                        {
                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.Property<string>("SecondName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("SecondName");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customer", "Core");
                });

            modelBuilder.Entity("MagCoders.Orders.Modules.Core.Domain.OrderAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Note");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("State");

                    b.ComplexProperty<Dictionary<string, object>>("Overall", "MagCoders.Orders.Modules.Core.Domain.OrderAggregate.Overall#Money", b1 =>
                        {
                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Overall_Currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Overall_Value");
                        });

                    b.HasKey("Id");

                    b.ToTable("Order", "Core");
                });

            modelBuilder.Entity("MagCoders.Orders.Modules.Core.Domain.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<decimal>("Discount")
                        .HasPrecision(5, 4)
                        .HasColumnType("decimal(5,4)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderId");

                    b.Property<Guid>("Product")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("OriginalUnitPrice", "MagCoders.Orders.Modules.Core.Domain.OrderLine.OriginalUnitPrice#Money", b1 =>
                        {
                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OriginalUnitPrice_Currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("OriginalUnitPrice_Value");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Price", "MagCoders.Orders.Modules.Core.Domain.OrderLine.Price#Money", b1 =>
                        {
                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Price_Currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price_Value");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("UnitPrice", "MagCoders.Orders.Modules.Core.Domain.OrderLine.UnitPrice#Money", b1 =>
                        {
                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UnitPrice_Currency");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("UnitPrice_Value");
                        });

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLine", "Core");
                });

            modelBuilder.Entity("MagCoders.Orders.Shared.Domain.DomainEventStore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("DomainEventStore", "Core");
                });

            modelBuilder.Entity("MagCoders.Orders.Modules.Core.Domain.OrderLine", b =>
                {
                    b.HasOne("MagCoders.Orders.Modules.Core.Domain.OrderAggregate", null)
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MagCoders.Orders.Modules.Core.Domain.OrderAggregate", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
