﻿// <auto-generated />
using System;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230605190606_addNewTables.3")]
    partial class addNewTables3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Domain.Entity.Account.AccountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountDetails")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Other_account_details");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOpened")
                        .HasColumnType("date")
                        .HasColumnName("Date_opened");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Account_name");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Account.AccountTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Account_description");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BecomeCostumer")
                        .HasColumnType("date")
                        .HasColumnName("Date_became_customer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Customer_email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Customer_name");

                    b.Property<int>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("Customer_phone");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerPurchaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductAndServicesId")
                        .HasColumnType("int");

                    b.Property<int>("Quantitty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductAndServicesId");

                    b.ToTable("CustomerPurchases");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Merchants.MerchantsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Merchant_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Merchants_name");

                    b.Property<int>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("Merchant_phone");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Merchants.ProductAndServicesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("products_and_services_descriptions");

                    b.Property<int>("MerchantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("ProductsAndServices");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Transactions.TransactionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("real")
                        .HasColumnName("Amount_of_transaction");

                    b.Property<int?>("CustomerPurchaseModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Other_Details");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerPurchaseModelId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Transactions.TransactionTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Trabsaction_type_description");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Account.AccountModel", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Account.AccountTypeModel", "Type")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bank.Domain.Entity.Customer.CustomerModel", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerModel", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Customer.CustomerTypeModel", "Type")
                        .WithMany("Customers")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerPurchaseModel", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Customer.CustomerModel", "Customer")
                        .WithMany("CustomerPurchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bank.Domain.Entity.Merchants.ProductAndServicesModel", "ProductAndServices")
                        .WithMany("CustomerPurchase")
                        .HasForeignKey("ProductAndServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ProductAndServices");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Merchants.ProductAndServicesModel", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Merchants.MerchantsModel", "Merchant")
                        .WithMany("ProDuctsAndServices")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Transactions.TransactionModel", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Account.AccountModel", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bank.Domain.Entity.Customer.CustomerPurchaseModel", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerPurchaseModelId");

                    b.HasOne("Bank.Domain.Entity.Transactions.TransactionTypeModel", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Account.AccountModel", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Account.AccountTypeModel", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerModel", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("CustomerPurchases");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerPurchaseModel", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer.CustomerTypeModel", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Merchants.MerchantsModel", b =>
                {
                    b.Navigation("ProDuctsAndServices");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Merchants.ProductAndServicesModel", b =>
                {
                    b.Navigation("CustomerPurchase");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Transactions.TransactionTypeModel", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
