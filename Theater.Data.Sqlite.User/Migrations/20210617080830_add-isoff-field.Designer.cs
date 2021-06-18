﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Theater.Data.Sqlite.User;

namespace Theater.Data.Sqlite.User.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20210617080830_add-isoff-field")]
    partial class addisofffield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Theater.Data.Sqlite.User.Login", b =>
                {
                    b.Property<string>("LoginId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOff")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginId");

                    b.HasIndex("UserID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("Theater.Data.Sqlite.User.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Theater.Data.Sqlite.User.Login", b =>
                {
                    b.HasOne("Theater.Data.Sqlite.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
