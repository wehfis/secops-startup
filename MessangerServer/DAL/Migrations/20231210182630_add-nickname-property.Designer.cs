﻿// <auto-generated />
using System;
using DAL.DBContex;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DbAplicationContext))]
    [Migration("20231210182630_add-nickname-property")]
    partial class addnicknameproperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BLL.Core.Domain.Dialog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Dialogs");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            RecipientId = 2L,
                            SenderId = 1L
                        },
                        new
                        {
                            Id = 101L,
                            RecipientId = 3L,
                            SenderId = 1L
                        },
                        new
                        {
                            Id = 102L,
                            RecipientId = 4L,
                            SenderId = 1L
                        },
                        new
                        {
                            Id = 103L,
                            RecipientId = 4L,
                            SenderId = 3L
                        },
                        new
                        {
                            Id = 104L,
                            RecipientId = 2L,
                            SenderId = 3L
                        });
                });

            modelBuilder.Entity("BLL.Core.Domain.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DialogId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 5000L,
                            Content = "Hi there John!",
                            DialogId = 100L,
                            Time = new DateTime(2020, 3, 15, 7, 1, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5001L,
                            Content = "Hi there!",
                            DialogId = 101L,
                            Time = new DateTime(2020, 3, 15, 7, 2, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5002L,
                            Content = "Hi there!",
                            DialogId = 102L,
                            Time = new DateTime(2020, 3, 15, 7, 3, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5003L,
                            Content = "Hi there!",
                            DialogId = 103L,
                            Time = new DateTime(2020, 3, 15, 7, 4, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5004L,
                            Content = "Hi there!",
                            DialogId = 104L,
                            Time = new DateTime(2020, 3, 15, 7, 5, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5005L,
                            Content = "Hi there!",
                            DialogId = 102L,
                            Time = new DateTime(2020, 3, 15, 7, 6, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5006L,
                            Content = "Hi there!",
                            DialogId = 104L,
                            Time = new DateTime(2020, 3, 15, 7, 7, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5007L,
                            Content = "Hi there!",
                            DialogId = 100L,
                            Time = new DateTime(2020, 3, 15, 7, 8, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BLL.Core.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "William",
                            Password = "sifjokasfp212"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "John",
                            Password = "12312sadads"
                        },
                        new
                        {
                            Id = 3L,
                            Email = "Alex",
                            Password = "asjdgukah19091"
                        },
                        new
                        {
                            Id = 4L,
                            Email = "Jane",
                            Password = "sasfjguahs21"
                        });
                });

            modelBuilder.Entity("BLL.Core.Domain.Dialog", b =>
                {
                    b.HasOne("BLL.Core.Domain.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("BLL.Core.Domain.User", "Sender")
                        .WithMany("Dialogs")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("BLL.Core.Domain.Message", b =>
                {
                    b.HasOne("BLL.Core.Domain.Dialog", "Dialog")
                        .WithMany("Messages")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dialog");
                });

            modelBuilder.Entity("BLL.Core.Domain.Dialog", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("BLL.Core.Domain.User", b =>
                {
                    b.Navigation("Dialogs");
                });
#pragma warning restore 612, 618
        }
    }
}
