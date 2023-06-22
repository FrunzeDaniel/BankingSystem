using Bank.Domain;
using Bank.Domain.Entity.Merchants;
using Bank.Interfaces;
namespace Bank.Repository;

public class MerchantRepository : IMerchantRepository
{
    private readonly AppDbContext _context;

    public MerchantRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateMerchant(MerchantsModel merchant)
    {
        _context.Merchants.Add(merchant);
                _context.SaveChanges();
    }

    public List<MerchantsModel> GetAllMerchants()
    {
        return _context.Merchants.ToList();
    }

    public MerchantsModel GetMerchantById(int id)
    {
        return _context.Merchants.Where(m => m.Id == id).FirstOrDefault();
    }
}