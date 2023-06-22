using Bank.Domain.Entity.Transactions;

namespace Bank.Interfaces;

public interface ITransactionRepository
{
    public void CreateTransaction(TransactionModel transaction);
    public List<TransactionModel> GetAccountTransactions(int accountId);
    public List<TransactionModel> GetAllUserTransactions(int userId);
    public TransactionModel GetTransactionById(int id);
}