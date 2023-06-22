using System.Runtime.CompilerServices;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Merchants;
using Bank.Domain.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Bank.Domain;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<CustomerTypeModel> CustomerTypes { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<CustomerPurchaseModel> CustomerPurchases { get; set; }
    public DbSet<AccountTypeModel> AccountTypes { get; set; }
    public DbSet<AccountModel> Accounts { get; set; }
    public DbSet<MerchantsModel> Merchants { get; set; }
    public DbSet<ProductAndServicesModel> ProductsAndServices { get; set; }
    public DbSet<TransactionModel> Transactions { get; set; }
    public DbSet<TransactionTypeModel> TransactionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customer models    

        modelBuilder.Entity<CustomerTypeModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).IsRequired();
        });

        modelBuilder.Entity<CustomerModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired()
                .HasMaxLength(40).HasColumnName("Customer_name");
            entity.Property(e => e.Phone).IsRequired()
                .HasMaxLength(10).HasColumnName("Customer_phone");
            entity.Property(e => e.Email).IsRequired()
                .HasMaxLength(40).HasColumnName("Customer_email");
            entity.Property(e => e.BecomeCostumer).IsRequired()
                .HasColumnName("Date_became_customer");
            entity.Property(e => e.Login).IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.password).IsRequired()
                .HasMaxLength(40);
            entity.HasOne(e => e.Type)
                .WithMany(c => c.Customers)
                .HasForeignKey(e => e.TypeId);
        });

        modelBuilder.Entity<CustomerPurchaseModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Quantitty).IsRequired();
            entity.HasOne(e => e.Customer)
                .WithMany(e => e.CustomerPurchases)
                .HasForeignKey(e => e.CustomerId);
            entity.HasOne(e => e.ProductAndServices)
                .WithMany(e => e.CustomerPurchase)
                .HasForeignKey(e => e.ProductAndServicesId);
            entity.HasMany(e => e.Transactions)
                .WithOne(e => e.CustomerPurchase)
                .HasForeignKey(e => e.PurchaseId)
                .OnDelete(DeleteBehavior.NoAction);
        });
       
// Acoount models        

        modelBuilder.Entity<AccountTypeModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(100)
                .HasColumnName("Account_description");
        });

        modelBuilder.Entity<AccountModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired()
                .HasMaxLength(40).HasColumnName("Account_name");
            entity.Property(e => e.DateOpened).IsRequired()
                .HasColumnName("Date_opened");
            entity.Property(e => e.AccountDetails).HasMaxLength(100)
                .HasColumnName("Other_account_details").IsRequired(false);
            entity.HasOne(e => e.Type)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.AccountTypeId);
            entity.HasOne(e => e.Customer)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.CustomerId);
        });
        
        
// Transactions Models
        modelBuilder.Entity<TransactionTypeModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).IsRequired(false)
                .HasMaxLength(100).HasColumnName("Trabsaction_type_description");
        });

        modelBuilder.Entity<TransactionModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Amount).IsRequired()
                .HasColumnName("Amount_of_transaction");
            entity.Property(e => e.Details).IsRequired(false)
                .HasMaxLength(100).HasColumnName("Other_Details");
            entity.HasOne(e => e.TransactionType)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.TransactionTypeId);
            // entity.HasOne(e => e.CustomerPurchase)
            //     .WithMany(e => e.Transactions)
            //     .HasForeignKey(e => e.PurchaseId);
            entity.HasOne(e => e.Account)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.AccountId);
        });
        
// Merchants models
        modelBuilder.Entity<MerchantsModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired()
                .HasMaxLength(40).HasColumnName("Merchants_name");
            entity.Property(e => e.Phone).IsRequired()
                .HasMaxLength(10).HasColumnName("Merchant_phone");
            entity.Property(e => e.Email).IsRequired()
                .HasMaxLength(40).HasColumnName("Merchant_email");
        });

        modelBuilder.Entity<ProductAndServicesModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).IsRequired(false)
                .HasMaxLength(100).HasColumnName("products_and_services_descriptions");
            entity.HasOne(e => e.Merchant)
                .WithMany(e => e.ProDuctsAndServices)
                .HasForeignKey(e => e.MerchantId);
        });
    }
}