using Bank.Domain.Entity.Merchants;

namespace Bank.Interfaces;

public interface IMerchantRepository
{
    public void CreateMerchant(MerchantsModel merchant);
    public List<MerchantsModel> GetAllMerchants();
    public MerchantsModel GetMerchantById(int id);
}