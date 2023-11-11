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
    [Migration("20231107162127_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Dialog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SecFlowMessenger.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DialogId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ResipientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DialogId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DAL.Models.Dialog", b =>
                {
                    b.HasOne("DAL.Models.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("DAL.Models.User", "Sender")
                        .WithMany("Dialogs")
                        .HasForeignKey("SenderId");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SecFlowMessenger.Models.Message", b =>
                {
                    b.HasOne("DAL.Models.Dialog", "Dialog")
                        .WithMany("Messages")
                        .HasForeignKey("DialogId");

                    b.Navigation("Dialog");
                });

            modelBuilder.Entity("DAL.Models.Dialog", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Dialogs");
                });
#pragma warning restore 612, 618
        }
    }
}