using Bank.Domain.Entity.Transactions;

namespace Bank.Interfaces;

public interface ITransactionTypeRepository
{
    public void CreateTransactionType(TransactionTypeModel type);
    public List<TransactionTypeModel> GetAllTransactionTypes();
    public TransactionTypeModel GetTransactionTypeById(int id);
}