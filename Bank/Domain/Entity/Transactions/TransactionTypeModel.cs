namespace Bank.Domain.Entity.Transactions;

public class TransactionTypeModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public List<TransactionModel> Transactions { get; set; }
    
}