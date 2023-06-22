using Bank.Domain.Entity.Customer;

namespace Bank.Domain.Entity.Merchants;

public class ProductAndServicesModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int MerchantId { get; set; }
    
    public MerchantsModel Merchant { get; set; }
    public List<CustomerPurchaseModel> CustomerPurchase { get; set; }
}