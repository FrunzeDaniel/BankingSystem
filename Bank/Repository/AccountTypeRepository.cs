using Bank.Domain;
using Bank.Domain.Entity.Account;
using Bank.Interfaces;

namespace Bank.Repository;

public class AccountTypeRepository : IAccountTypeRepository
{
    private readonly AppDbContext _context;

    public AccountTypeRepository(AppDbContext context)
    {
        _context = context;
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