﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API.DataContext;

#nullable disable

namespace WEB_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(5997),
                            DueDate = new DateTime(2025, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(5997),
                            Status = 0,
                            Summary = "Ir ao futebol.",
                            Title = "Futebol",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(6001),
                            DueDate = new DateTime(2025, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(6002),
                            Status = 1,
                            Summary = "Ir ao mercado.",
                            Title = "Mercado",
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(6004),
                            DueDate = new DateTime(2025, 7, 14, 19, 16, 26, 313, DateTimeKind.Local).AddTicks(6004),
                            Status = 2,
                            Summary = "Finalizar o teste.",
                            Title = "Teste de Programação",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WEB_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Password = "admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "leonardothomazellif@gmail.com",
                            Password = "123456",
                            UserName = "Leonardo"
                        },
                        new
                        {
                            Id = 3,
                            Email = "geraneves@gmail.com",
                            Password = "654321",
                            UserName = "Geraldo"
                        });
                });

            modelBuilder.Entity("WEB_API.Models.Tasks", b =>
                {
                    b.HasOne("WEB_API.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WEB_API.Models.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
