﻿// <auto-generated />
using System;
using Bank_Branches_Mini_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Branches_Mini_Project.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240424072200_RemovedBankBranchFromEmployeeModel")]
    partial class RemovedBankBranchFromEmployeeModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Bank_Branches_Mini_Project.Models.BankBranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BankBranches");
                });

            modelBuilder.Entity("Bank_Branches_Mini_Project.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BankBranchModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankBranchModelId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bank_Branches_Mini_Project.Models.EmployeeModel", b =>
                {
                    b.HasOne("Bank_Branches_Mini_Project.Models.BankBranchModel", null)
                        .WithMany("Employees")
                        .HasForeignKey("BankBranchModelId");
                });

            modelBuilder.Entity("Bank_Branches_Mini_Project.Models.BankBranchModel", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
