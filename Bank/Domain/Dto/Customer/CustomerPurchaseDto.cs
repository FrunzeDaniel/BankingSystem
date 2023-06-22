namespace Bank.Domain.Dto.Customer;

public class CustomerPurchaseDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantitty { get; set; }
    public int CustomerId { get; set; }
    public int ProductAndServicesId { get; set; }
}