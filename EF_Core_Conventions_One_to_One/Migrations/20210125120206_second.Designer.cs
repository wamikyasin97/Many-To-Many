﻿// <auto-generated />
using EF_Core_Conventions_One_to_One;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_Conventions_One_to_One.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20210125120206_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EF_Core_Conventions_One_to_One.Address", b =>
                {
                    b.Property<int>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("addressId");

                    b.HasIndex("studentId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EF_Core_Conventions_One_to_One.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("studentAge")
                        .HasColumnType("int");

                    b.Property<string>("studentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EF_Core_Conventions_One_to_One.Address", b =>
                {
                    b.HasOne("EF_Core_Conventions_One_to_One.Student", "student")
                        .WithOne("studentAddress")
                        .HasForeignKey("EF_Core_Conventions_One_to_One.Address", "studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("EF_Core_Conventions_One_to_One.Student", b =>
                {
                    b.Navigation("studentAddress");
                });
#pragma warning restore 612, 618
        }
    }
}