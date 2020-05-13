﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raunstrup_Webapplication.Data;

namespace Raunstrup_Webapplication.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200512124142_AddedServiceLineModel")]
    partial class AddedServiceLineModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.CustomerModel", b =>
                {
                    b.Property<int>("Costumor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Custumor_Group")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Phone_Num")
                        .HasColumnType("int");

                    b.HasKey("Costumor_Id");

                    b.ToTable("CustomerModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Expertise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Employee_ID");

                    b.ToTable("EmployeeModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.EmployeeOfferModel", b =>
                {
                    b.Property<int>("EmployeeOffer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ForeignKey1_Offer_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ForeignKey2_Employee_ID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeOffer_ID");

                    b.HasIndex("ForeignKey1_Offer_ID");

                    b.HasIndex("ForeignKey2_Employee_ID");

                    b.ToTable("EmployeeOfferModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.EmployeeVehicleModel", b =>
                {
                    b.Property<int>("License_Plate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Day_Price")
                        .HasColumnType("float");

                    b.Property<int?>("ForeignKey1_Employee_ID")
                        .HasColumnType("int");

                    b.Property<double>("Km_Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("License_Plate");

                    b.HasIndex("ForeignKey1_Employee_ID");

                    b.ToTable("EmployeeVehicleModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.OfferModel", b =>
                {
                    b.Property<int>("Offer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ForeignKey1_Costumor_Id")
                        .HasColumnType("int");

                    b.Property<double>("Offer_Price")
                        .HasColumnType("float");

                    b.Property<string>("Offer_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_date")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Offer_ID");

                    b.HasIndex("ForeignKey1_Costumor_Id");

                    b.ToTable("OfferModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.OrderModel", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ForeignKey1_Offer_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ForeignKey2_Costumor_Id")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Order_ID");

                    b.HasIndex("ForeignKey1_Offer_ID");

                    b.HasIndex("ForeignKey2_Costumor_Id");

                    b.ToTable("OrderModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.ResourceModel", b =>
                {
                    b.Property<int>("Res_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Customer_Price")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Store_Price")
                        .HasColumnType("float");

                    b.HasKey("Res_ID");

                    b.ToTable("ResourceModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.ServiceLineModel", b =>
                {
                    b.Property<int>("Service_Line_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ForeignKey1_Res_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ForeignKey2_Service_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ForeignKey3_Offer_ID")
                        .HasColumnType("int");

                    b.Property<int>("Resource_Quantity")
                        .HasColumnType("int");

                    b.HasKey("Service_Line_ID");

                    b.HasIndex("ForeignKey1_Res_ID");

                    b.HasIndex("ForeignKey2_Service_ID");

                    b.HasIndex("ForeignKey3_Offer_ID");

                    b.ToTable("ServiceLineModel");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.ServiceModel", b =>
                {
                    b.Property<int>("Service_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Service_ID");

                    b.ToTable("ServiceModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.EmployeeOfferModel", b =>
                {
                    b.HasOne("Raunstrup_Webapplication.Models.OfferModel", "ForeignKey1_")
                        .WithMany()
                        .HasForeignKey("ForeignKey1_Offer_ID");

                    b.HasOne("Raunstrup_Webapplication.Models.EmployeeModel", "ForeignKey2_")
                        .WithMany()
                        .HasForeignKey("ForeignKey2_Employee_ID");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.EmployeeVehicleModel", b =>
                {
                    b.HasOne("Raunstrup_Webapplication.Models.EmployeeModel", "ForeignKey1_")
                        .WithMany()
                        .HasForeignKey("ForeignKey1_Employee_ID");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.OfferModel", b =>
                {
                    b.HasOne("Raunstrup_Webapplication.Models.CustomerModel", "ForeignKey1_")
                        .WithMany()
                        .HasForeignKey("ForeignKey1_Costumor_Id");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.OrderModel", b =>
                {
                    b.HasOne("Raunstrup_Webapplication.Models.OfferModel", "ForeignKey1_")
                        .WithMany()
                        .HasForeignKey("ForeignKey1_Offer_ID");

                    b.HasOne("Raunstrup_Webapplication.Models.CustomerModel", "ForeignKey2_")
                        .WithMany()
                        .HasForeignKey("ForeignKey2_Costumor_Id");
                });

            modelBuilder.Entity("Raunstrup_Webapplication.Models.ServiceLineModel", b =>
                {
                    b.HasOne("Raunstrup_Webapplication.Models.ResourceModel", "ForeignKey1_")
                        .WithMany()
                        .HasForeignKey("ForeignKey1_Res_ID");

                    b.HasOne("Raunstrup_Webapplication.Models.ServiceModel", "ForeignKey2_")
                        .WithMany()
                        .HasForeignKey("ForeignKey2_Service_ID");

                    b.HasOne("Raunstrup_Webapplication.Models.OfferModel", "ForeignKey3_")
                        .WithMany()
                        .HasForeignKey("ForeignKey3_Offer_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
