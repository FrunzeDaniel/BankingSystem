using Bank.Domain.Entity.Account;

namespace Bank.Domain.Entity.Customer;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }
    public DateOnly BecomeCostumer { get; set; }
    public string Login { get; set; }
    public string password { get; set; }
    public int TypeId { get; set; }
    
    public CustomerTypeModel? Type { get; set; }
    public List<AccountModel>? Accounts { get; set; }
    public List<CustomerPurchaseModel>? CustomerPurchases { get; set; }
    
}