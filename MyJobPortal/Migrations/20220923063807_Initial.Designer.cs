﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyJobPortal.Data;

namespace MyJobPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220923063807_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJobPortal.Models.AccountStatus", b =>
                {
                    b.Property<int>("AccountStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("AccountStatusId");

                    b.ToTable("AccountStatuses");
                });

            modelBuilder.Entity("MyJobPortal.Models.UserTable", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("UserTables");
                });

            modelBuilder.Entity("MyJobPortal.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("MyJobPortal.Models.UserTable", b =>
                {
                    b.HasOne("MyJobPortal.Models.AccountStatus", "AccountStatus")
                        .WithMany("UserTables")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyJobPortal.Models.UserType", "UserType")
                        .WithMany("UserTables")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
