using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Account;
using Bank.Domain.Dto.Customer;
using Bank.Domain.Dto.Merchants;
using Bank.Domain.Dto.Transaction;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Merchants;
using Bank.Domain.Entity.Transactions;
using TransactionTypeModel = Bank.Domain.Entity.Transactions.TransactionTypeModel;

namespace Bank.Helper;

public class MappingProfiles : Profile
{
    private readonly AppDbContext _context;

    public MappingProfiles(AppDbContext context)
    {
        _context = context;
        if(_context == null)
            Console.WriteLine("Is null");
        CreateMap<CustomerModel, CustomerDto>();
        CreateMap<CustomerDto, CustomerModel>();
        CreateMap<CustomerTypeModel, CustomerTypeDto>();
        CreateMap<CustomerPurchaseModel, CustomerPurchaseDto>();
        
        CreateMap<AccountModel, AccountDto>();
        CreateMap<AccountModel, GetAccountDto>()
            .ForMember(t => t.AccountType, opt => 
                opt.MapFrom(a => _context.AccountTypes.FirstOrDefault(t => t.Id == a.AccountTypeId).Description))
            .ForMember(t => t.Customer, opt => 
                opt.MapFrom(a => _context.Customers.FirstOrDefault(c => c.Id == a.CustomerId).Name));
        CreateMap<AccountTypeModel, AccountTypeDto>();

        CreateMap<MerchantsModel, MerchantsDto>();
        CreateMap<ProductAndServicesModel, ProductsAndServicesDto>();

        CreateMap<TransactionModel, TransactionDto>();
        CreateMap<TransactionTypeModel, TransactionTypeDto>();
    }
}