namespace Bank.Domain.Entity.Merchants;

public class MerchantsModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public string Email { get; set; }
    
    public List<ProductAndServicesModel> ProDuctsAndServices { get; set; }

}