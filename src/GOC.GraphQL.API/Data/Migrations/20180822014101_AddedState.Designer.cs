﻿// <auto-generated />
using GOC.GraphQL.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GOC.GraphQL.API.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180822014101_AddedState")]
    partial class AddedState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("GOC.GraphQL.API.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<int?>("CustomerId");

                    b.Property<int?>("StateId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StateId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GOC.GraphQL.API.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GOC.GraphQL.API.Data.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("GOC.GraphQL.API.Data.Models.Address", b =>
                {
                    b.HasOne("GOC.GraphQL.API.Data.Models.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");

                    b.HasOne("GOC.GraphQL.API.Data.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });
#pragma warning restore 612, 618
        }
    }
}