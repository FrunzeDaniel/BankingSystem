using Bank.Domain;
using Bank.Domain.Entity.Merchants;
using Bank.Interfaces;
namespace Bank.Repository;

public class ProductAndServicesRepository : IProductAndServicesRepository
{
    private readonly AppDbContext _context;

    public ProductAndServicesRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateProductOrService(ProductAndServicesModel productOrService)
    {
        _context.ProductsAndServices.Add(productOrService);
        _context.SaveChanges();
    }

    public List<ProductAndServicesModel> GetAllOriductsAndServices()
    {
        return _context.ProductsAndServices.ToList();
    }

    public List<ProductAndServicesModel> GetMerchantProductAndServices(int merchantId)
    {
        return _context.Merchants.Where(m => m.Id == merchantId).SelectMany(m => m.ProDuctsAndServices).ToList();
    }

    public ProductAndServicesModel GetProductOrServiceById(int id)
    {
        return _context.ProductsAndServices.Where(ps => ps.Id == id).FirstOrDefault();
    }
}