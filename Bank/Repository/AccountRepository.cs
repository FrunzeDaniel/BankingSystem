using Bank.Domain;
using Bank.Domain.Entity.Account;
using Bank.Interfaces;

namespace Bank.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateNewAccount(AccountModel account)
    {
        _context.Accounts.Add(account);
                _context.SaveChanges();
    }

    public List<AccountModel> GetUserAccount(int userId)
    {
        return _context.Customers.Where(c => c.Id == userId).SelectMany(a => a.Accounts).ToList();
    }
}