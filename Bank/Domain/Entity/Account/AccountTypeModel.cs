using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity.Account;

public class AccountTypeModel
{
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    public List<AccountModel> Accounts { get; set; }
}