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

    public List<AccountModel> GetUserAccounts(int userId)
    {
        return _context.Customers.Where(c => c.Id == userId).SelectMany(a => a.Accounts).ToList();
    }

    public AccountModel GetAccountById(int id)
    {
        return _context.Accounts.Where(a => a.Id == id).FirstOrDefault();
    }
    
    public void CreateAccountType(AccountTypeModel accountType)
    {
        _context.AccountTypes.Add(accountType);
        _context.SaveChanges();
    }

    public List<AccountTypeModel> GetAccountsTypes()
    {
        return _context.AccountTypes.ToList();
    }

    public AccountTypeModel GetAccountTypeById(int id)
    {
        return _context.AccountTypes.Where(t => t.Id == id).FirstOrDefault();
    }
}