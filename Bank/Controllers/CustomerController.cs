using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Customer;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    
    public CustomerController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpPost("CreateCustomerType")]
    public IActionResult CreateCustomerType([FromBody]CustomerTypeDto typeDto)
    {
        var type = _mapper.Map<CustomerTypeDto, CustomerTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        type.Customers = new List<CustomerModel>();
        _context.CustomerTypes.Add(type);
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpGet("GetCustomerTypes")]
    public IActionResult GetCustomerTypes()
    {
        List<CustomerTypeModel> types = _context.CustomerTypes.ToList();
        List<CustomerTypeDto> typeDtos = _mapper.Map<List<CustomerTypeModel>, List<CustomerTypeDto>>(types);

        return Ok(typeDtos);
    }

    [HttpPost("CreateCustomer")]
    public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
    {
        var customer = _mapper.Map<CustomerDto, CustomerModel>(customerDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        customer.Accounts = new List<AccountModel>();
        customer.CustomerPurchases = new List<CustomerPurchaseModel>();
        customer.Type = _context.CustomerTypes.FirstOrDefault(t => t.Id == customer.TypeId);
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("GetCustomer/{id}")]
    public IActionResult GetCustomer(int id)
    {
        CustomerDto customer = _mapper.Map<CustomerModel, CustomerDto>(
            _context.Customers.FirstOrDefault(c => c.Id == id));

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("GetAllCustomers")]
    public IActionResult GetAllCustomers()
    {
        List<CustomerDto> customers = _mapper.Map<List<CustomerModel>, List<CustomerDto>>(
            _context.Customers.ToList());

        return Ok(customers);
    }

    [HttpPost("MakePurchase")]
    public IActionResult MakePurchase([FromBody] CustomerPurchaseDto purchaseDto)
    {
        var purchase = _mapper.Map<CustomerPurchaseDto, CustomerPurchaseModel>(purchaseDto);

        if (!ModelState.IsValid)
            return BadRequest("invalid data!");
        
        purchase.Transactions = new List<TransactionModel>();
        purchase.Customer = _context.Customers.FirstOrDefault(c => c.Id == purchase.CustomerId);
        purchase.ProductAndServices =
            _context.ProductsAndServices.FirstOrDefault(p => p.Id == purchase.ProductAndServicesId);

        _context.CustomerPurchases.Add(purchase);
        _context.SaveChanges();
        return Ok();
    }
    
}