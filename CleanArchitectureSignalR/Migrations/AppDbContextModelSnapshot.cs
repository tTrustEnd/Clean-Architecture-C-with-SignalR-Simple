﻿// <auto-generated />
using System;
using CleanArchitectureSignalR.Infrastructure.SpLite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitectureSignalR.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CleanArchitectureSignalR.Core.Entities.Message", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SendAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("Message", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
