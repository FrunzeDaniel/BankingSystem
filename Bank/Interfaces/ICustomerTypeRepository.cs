using Bank.Domain.Entity.Customer;

namespace Bank.Interfaces;

public interface ICustomerTypeRepository
{
    public List<CustomerTypeModel> GetCustomerTypes();
    public void CreateNewCustomerType(CustomerTypeModel customerType);

    public List<CustomerModel> GetCustomersByType(int typeId);
    public CustomerTypeModel GetCustomerTypeById(int id);
}