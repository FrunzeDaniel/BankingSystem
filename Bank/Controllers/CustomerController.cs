using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Customer;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Customer;
using Bank.Domain.Entity.Transactions;
using Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerTypeRepository _customerTypeRepository;
    private readonly IMapper _mapper;
    
    public CustomerController(ICustomerRepository customerRepository, ICustomerTypeRepository customerTypeRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _customerTypeRepository = customerTypeRepository;
        _mapper = mapper;
    }
    
    [HttpPost("CreateCustomerType")]
    public IActionResult CreateCustomerType([FromBody]CustomerTypeDto typeDto)
    {
        var type = _mapper.Map<CustomerTypeDto, CustomerTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        type.Customers = new List<CustomerModel>();
        _customerTypeRepository.CreateNewCustomerType(type);
        return Ok();
    }
    
    [HttpGet("GetCustomerTypes")]
    public IActionResult GetCustomerTypes()
    {
        List<CustomerTypeDto> typeDtos = _mapper.Map<List<CustomerTypeModel>, List<CustomerTypeDto>>(_customerTypeRepository.GetCustomerTypes());

        return Ok(typeDtos);
    }

    [HttpPost("CreateCustomer")]
    public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
    {
        var customer = _mapper.Map<CustomerModel>(customerDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        customer.Accounts = new List<AccountModel>();
        customer.CustomerPurchases = new List<CustomerPurchaseModel>();
        customer.Type = _customerTypeRepository.GetCustomerTypeById(customer.TypeId);
        _customerRepository.CreateNewCustomer(customer);
        return Ok();
    }

    [HttpGet("GetCustomer/{id}")]
    public IActionResult GetCustomer(int id)
    {
        CustomerDto customer = _mapper.Map<CustomerModel, CustomerDto>(
            _customerRepository.GetCustomer(id));

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
    
    [HttpGet("GetCustomerByName/{name}")]
    public IActionResult GetCustomer(string name)
    {
        CustomerDto customer = _mapper.Map<List<CustomerModel>, CustomerDto>(
            _customerRepository.GetCustomersByName(name));

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpGet("GetAllCustomers")]
    public IActionResult GetAllCustomers()
    {
        List<CustomerDto> customers = _mapper.Map<List<CustomerModel>, List<CustomerDto>>(
            _customerRepository.GetCustomers());
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(customers);
    }

    // [HttpPost("MakePurchase")]
    // public IActionResult MakePurchase([FromBody] CustomerPurchaseDto purchaseDto)
    // {
    //     var purchase = _mapper.Map<CustomerPurchaseDto, CustomerPurchaseModel>(purchaseDto);
    //
    //     if (!ModelState.IsValid)
    //         return BadRequest("invalid data!");
    //     
    //     purchase.Transactions = new List<TransactionModel>();
    //     purchase.Customer = _context.Customers.FirstOrDefault(c => c.Id == purchase.CustomerId);
    //     purchase.ProductAndServices =
    //         _context.ProductsAndServices.FirstOrDefault(p => p.Id == purchase.ProductAndServicesId);
    //
    //     _context.CustomerPurchases.Add(purchase);
    //     _context.SaveChanges();
    //     return Ok();
    // }
    
}