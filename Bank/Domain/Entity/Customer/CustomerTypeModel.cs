using System.ComponentModel.DataAnnotations;

namespace Bank.Domain.Entity.Customer;

public class CustomerTypeModel
{
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    public List<CustomerModel>? Customers { get; set; }
}