using Bank.Domain.Entity.Merchants;

namespace Bank.Interfaces;

public interface IProductAndServicesRepository
{
    public void CreateProductOrService(ProductAndServicesModel productOrService);
    public List<ProductAndServicesModel> GetAllOriductsAndServices();
    public List<ProductAndServicesModel> GetMerchantProductAndServices(int merchantId);
    public ProductAndServicesModel GetProductOrServiceById(int id);

}