using Bank.Domain.Entity.Customer;

namespace Bank.Interfaces;

public interface ICustomerPurchaseRepository
{
    public void CreatePurchase(CustomerPurchaseModel purchase);
    public CustomerPurchaseModel GetPurchaseById(int id);
    
}