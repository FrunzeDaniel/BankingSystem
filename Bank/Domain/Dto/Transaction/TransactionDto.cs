namespace Bank.Domain.Dto.Transaction;

public class TransactionDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public float Amount { get; set; }
    public string Details { get; set; }
    public int PurchaseId { get; set; }
    public int AccountId { get; set; }
    public int TransactionTypeId { get; set; }
}