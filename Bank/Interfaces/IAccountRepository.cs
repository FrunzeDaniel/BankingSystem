using Bank.Domain.Entity.Account;

namespace Bank.Interfaces;

public interface IAccountRepository
{
    public void CreateNewAccount(AccountModel account);
    public List<AccountModel> GetUserAccounts(int userId);
}