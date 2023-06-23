﻿using Bank.Domain.Entity.Account;

namespace Bank.Interfaces;

public interface IAccountRepository
{
    public void CreateNewAccount(AccountModel account);
    public List<AccountModel> GetUserAccounts(int userId);
    public AccountModel GetAccountById(int id);
    public void CreateAccountType(AccountTypeModel accountType);
    public List<AccountTypeModel> GetAccountsTypes();
    public AccountTypeModel GetAccountTypeById(int id);
}