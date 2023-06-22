namespace Bank.Domain.Dto.Customer;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }
    public DateOnly BecomeCostumer { get; set; }
    public string Login { get; set; }
    public string password { get; set; }
    public int TypeId { get; set; }
}