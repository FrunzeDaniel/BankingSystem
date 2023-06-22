using System.Linq.Expressions;
using Bank.Domain;
using Bank.Domain.Entity.Customer;
using Bank.Interfaces;

namespace Bank.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool ChechForCustomerExistance<T>(IEnumerable<CustomerModel> customers,
        Expression<Func<CustomerModel, bool>> predicate)
    {
        return _context.Customers.Any(predicate);
    }

    public List<CustomerModel> GetCustomers()
    {
        return _context.Customers.OrderBy(c => c.Id).ToList();
    }

    public CustomerModel GetCustomer(int id)
    {
        return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
    }

    public List<CustomerModel> GetCustomersByName(string name)
    {
       return _context.Customers.Where(c => c.Name == name).ToList();
    }

    public void CreateNewCustomer(CustomerModel customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }
}