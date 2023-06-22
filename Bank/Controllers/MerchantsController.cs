using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Merchants;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Merchants;
using Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class MerchantsController : ControllerBase
{
    private readonly IMerchantRepository _merchantRepository;
    private readonly IProductAndServicesRepository _productAndServicesRepository;
    private readonly IMapper _mapper;
    
    public MerchantsController(IMerchantRepository merchantRepository, IProductAndServicesRepository productAndServicesRepository, IMapper mapper)
    {
        _merchantRepository = merchantRepository;
        _productAndServicesRepository = productAndServicesRepository;
        _mapper = mapper;
    }

    [HttpPost("CreateMerchant")]
    public IActionResult CreateMerchant([FromBody] MerchantsDto merchantDto)
    {
        var merchant = _mapper.Map<MerchantsDto, MerchantsModel>(merchantDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        merchant.ProDuctsAndServices = new List<ProductAndServicesModel>();
        _merchantRepository.CreateMerchant(merchant);
        
        return Ok();
    }
    
    [HttpGet("GetMerchant/{id}")]
    public IActionResult GetMerchant(int id)
    {
        MerchantsDto merchantDto = _mapper.Map<MerchantsModel, MerchantsDto>(_merchantRepository.GetMerchantById(id));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(merchantDto);
    }
    
    [HttpGet("GetAllMerchants")]
    public IActionResult GetAllMerchant()
    {
        List<MerchantsDto> merchants = _mapper.Map<List<MerchantsModel>, List<MerchantsDto>>(
            _merchantRepository.GetAllMerchants());
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(merchants);
    }

    [HttpPost("AddProductsAndServices")]
    public IActionResult AddProductsAndServices([FromBody] ProductsAndServicesDto productAndServicesDto)
    {
        var productAndServices = _mapper.Map<ProductsAndServicesDto, ProductAndServicesModel>(productAndServicesDto);
        
        if (!ModelState.IsValid)
            return BadRequest("Invalid Data!");

        productAndServices.CustomerPurchase = new List<CustomerPurchaseModel>();
        productAndServices.Merchant = _merchantRepository.GetMerchantById(productAndServices.MerchantId);

        _productAndServicesRepository.CreateProductOrService(productAndServices);

        return Ok();
    }
    
    [HttpGet("GetAllProductAndServices")]
    public IActionResult GetAllProductAndServices()
    {
        List<ProductsAndServicesDto> productAndServices = _mapper.Map<List<ProductAndServicesModel>, List<ProductsAndServicesDto>>(
            _productAndServicesRepository.GetAllOriductsAndServices());
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(productAndServices);
    }
    
    [HttpGet("GetProductOrService/{id}")]
    public IActionResult GetProducrOrService(int id)
    {
        ProductsAndServicesDto productsAndServices = _mapper.Map<ProductAndServicesModel, ProductsAndServicesDto>(_productAndServicesRepository.GetProductOrServiceById(id));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(productsAndServices);
    }

    [HttpGet("Merchant/products/{id}")]
    public IActionResult GetMerchantProductsAndServices(int id)
    {
        List<ProductsAndServicesDto> productsAndServices = _mapper.Map<List<ProductAndServicesModel>, List<ProductsAndServicesDto>>(_productAndServicesRepository.GetMerchantProductAndServices(id));
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(productsAndServices);
    }
    
}