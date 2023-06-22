using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Merchants;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Merchants;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class MerchantsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    
    public MerchantsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("CreateMerchant")]
    public IActionResult CreateMerchant([FromBody] MerchantsDto merchantDto)
    {
        var merchant = _mapper.Map<MerchantsDto, MerchantsModel>(merchantDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        merchant.ProDuctsAndServices = new List<ProductAndServicesModel>();
        _context.Merchants.Add(merchant);
        _context.SaveChanges();
        
        return Ok();
    }

    [HttpPost("AddProductsAndServices")]
    public IActionResult AddProductsAndServices([FromBody] ProductsAndServicesDto productAndServicesDto)
    {
        var productAndServices = _mapper.Map<ProductsAndServicesDto, ProductAndServicesModel>(productAndServicesDto);
        
        if (!ModelState.IsValid)
            return BadRequest("Invalid Data!");

        productAndServices.CustomerPurchase = new List<CustomerPurchaseModel>();
        productAndServices.Merchant = _context.Merchants.FirstOrDefault(m => m.Id == productAndServices.MerchantId);

        _context.ProductsAndServices.Add(productAndServices);
        _context.SaveChanges();

        return Ok();
    }
}