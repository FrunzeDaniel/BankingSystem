using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Transactions;

namespace Bank.Domain.Entity.Account;

public class AccountModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOpened { get; set; }
    public string AccountDetails { get; set; }
    public int AccountTypeId { get; set; }
    public int CustomerId { get; set; }
    
    public AccountTypeModel Type { get; set; }
    public CustomerModel Customer { get; set; }
    public List<TransactionModel> Transactions { get; set; }
}