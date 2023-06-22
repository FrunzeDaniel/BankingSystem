using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Customer;
using Microsoft.Identity.Client;

namespace Bank.Domain.Entity.Transactions;

public class TransactionModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public float Amount { get; set; }
    public string Details { get; set; }
    public int PurchaseId { get; set; }
    public int AccountId { get; set; }
    public int TransactionTypeId { get; set; }
    
    public TransactionTypeModel TransactionType { get; set; }
    public CustomerPurchaseModel CustomerPurchase { get; set; }
    public AccountModel Account { get; set; }
    
}