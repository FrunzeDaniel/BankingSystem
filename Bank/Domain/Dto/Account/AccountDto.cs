namespace Bank.Domain.Dto.Account;

public class AccountDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOpened { get; set; }
    public string AccountDetails { get; set; }
    public int AccountTypeId { get; set; }
    public int CustomerId { get; set; }
}