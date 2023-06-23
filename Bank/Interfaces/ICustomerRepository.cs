using System.Linq.Expressions;
using Bank.Domain.Entity.Customer;

namespace Bank.Interfaces;

public interface ICustomerRepository
{
    public bool ChechForCustomerExistance<T>(IEnumerable<CustomerModel> customers,
        Expression<Func<CustomerModel, bool>> predict);
    public List<CustomerModel> GetCustomers();
   // List<CustomerModel> GetCustomersByType(int typeId); moove to type interface
    public CustomerModel GetCustomer(int id);
    public List<CustomerModel> GetCustomersByName(string name);
    public void CreateNewCustomer(CustomerModel customer);
    public List<CustomerTypeModel> GetCustomerTypes();
    public void CreateNewCustomerType(CustomerTypeModel customerType);

    public List<CustomerModel> GetCustomersByType(int typeId);
    public CustomerTypeModel GetCustomerTypeById(int id);
}