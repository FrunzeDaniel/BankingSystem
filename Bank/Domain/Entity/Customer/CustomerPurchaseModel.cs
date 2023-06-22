using Bank.Domain.Entity.Merchants;
using Bank.Domain.Entity.Transactions;

namespace Bank.Domain.Entity.Customer;

public class CustomerPurchaseModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantitty { get; set; }
    public int CustomerId { get; set; }
    public int ProductAndServicesId { get; set; }
    
    public CustomerModel Customer { get; set; }
    public ProductAndServicesModel ProductAndServices { get; set; }
    
   public List<TransactionModel> Transactions { get; set; }

}