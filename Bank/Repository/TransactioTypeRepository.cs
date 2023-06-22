using Bank.Domain;
using Bank.Domain.Entity.Transactions;
using Bank.Interfaces;

namespace Bank.Repository;

public class TransactionTypeRepository : ITransactionTypeRepository
{
    private readonly AppDbContext _context;

    public TransactionTypeRepository(AppDbContext context)
    {
        _context = context;
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