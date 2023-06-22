namespace Bank.Domain.Dto.Account;

public class GetAccountDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOpened { get; set; }
    public string AccountDetails { get; set; }
    public string AccountType { get; set; }
    public string Customer { get; set; }
}