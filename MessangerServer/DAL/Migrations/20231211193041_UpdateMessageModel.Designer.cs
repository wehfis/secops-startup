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
    [Migration("20231211193041_UpdateMessageModel")]
    partial class UpdateMessageModel
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

                    b.HasKey("Id");

                    b.ToTable("Dialogs");
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
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
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
                });

            modelBuilder.Entity("BLL.Core.Domain.UserDialog", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("DialogId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "DialogId");

                    b.HasIndex("DialogId");

                    b.ToTable("UserDialogs");
                });

            modelBuilder.Entity("BLL.Core.Domain.Message", b =>
                {
                    b.HasOne("BLL.Core.Domain.Dialog", "Dialog")
                        .WithMany("Messages")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BLL.Core.Domain.User", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId");

                    b.Navigation("Dialog");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("BLL.Core.Domain.UserDialog", b =>
                {
                    b.HasOne("BLL.Core.Domain.Dialog", "Dialog")
                        .WithMany("UserDialogs")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BLL.Core.Domain.User", "User")
                        .WithMany("UserDialogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dialog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BLL.Core.Domain.Dialog", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserDialogs");
                });

            modelBuilder.Entity("BLL.Core.Domain.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserDialogs");
                });
#pragma warning restore 612, 618
        }
    }
}
