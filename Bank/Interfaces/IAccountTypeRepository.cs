using Bank.Domain.Entity.Account;

namespace Bank.Interfaces;

public interface IAccountTypeRepository
{
    public void CreateAccountType(AccountTypeModel accountType);
    public List<AccountTypeModel> GetAccountsTypes();
    public AccountTypeModel GetAccountTypeById(int id);
}