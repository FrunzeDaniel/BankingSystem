using Bank.Domain;
using Bank.Domain.Entity.Customer;
using Bank.Interfaces;

namespace Bank.Repository;

public class CustomerTypeRepository : ICustomerTypeRepository
{
    private readonly AppDbContext _context;

    public CustomerTypeRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public List<CustomerTypeModel> GetCustomerTypes()
    {
        return _context.CustomerTypes.OrderBy(t => t.Id).ToList();
    }

    public void CreateNewCustomerType(CustomerTypeModel customerType)
    {
        _context.CustomerTypes.Add(customerType);
        _context.SaveChanges();
    }

    public List<CustomerModel> GetCustomersByType(int typeId)
    {
        return _context.CustomerTypes.Where(t => t.Id == typeId).SelectMany(c => c.Customers).ToList();
    }

    public CustomerTypeModel GetCustomerTypeById(int id)
    {
        return _context.CustomerTypes.Where(t => t.Id == id).FirstOrDefault();
    }
}