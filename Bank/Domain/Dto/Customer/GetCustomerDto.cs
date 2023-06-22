namespace Bank.Domain.Dto.Customer;

public class GetCustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }
    public DateOnly BecomeCostumer { get; set; }
    public int Type { get; set; }
}