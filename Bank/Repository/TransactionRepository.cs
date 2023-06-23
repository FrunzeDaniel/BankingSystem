using Bank.Domain;
using Bank.Domain.Entity.Transactions;
using Bank.Interfaces;

namespace Bank.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateTransaction(TransactionModel transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public List<TransactionModel> GetAccountTransactions(int accountId)
    {
        return _context.Accounts.Where(a => a.Id == accountId).SelectMany(a => a.Transactions).ToList();
    }

    public List<TransactionModel> GetAllUserTransactions(int userId)
    {
        return _context.Customers.Where(c => c.Id == userId).SelectMany(c => c.Accounts)
            .SelectMany(a => a.Transactions).ToList();
    }

    public TransactionModel GetTransactionById(int id)
    {
        return _context.Transactions.Where(t => t.Id == id).FirstOrDefault();
    }
    public void CreateTransactionType(TransactionTypeModel type)
    {
        _context.TransactionTypes.Add(type);
        _context.SaveChanges();
    }

    public List<TransactionTypeModel> GetAllTransactionTypes()
    {
        return _context.TransactionTypes.ToList();
    }

    public TransactionTypeModel GetTransactionTypeById(int id)
    {
        return _context.TransactionTypes.Where(t => t.Id == id).FirstOrDefault();
    }
}