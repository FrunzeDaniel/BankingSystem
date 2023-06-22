using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Account;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Transactions;
using Bank.Interfaces;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountTypeRepository _accountTypeRepository;
    private readonly ICustomerRepository _customerRepository;

    public AccountController(IAccountRepository accountRepository, IAccountTypeRepository accountTypeRepository, ICustomerRepository customerRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _accountTypeRepository = accountTypeRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpPost("AddAccountType")]
    public IActionResult AddAccountType([FromBody]AccountTypeDto typeDto)
    {
        var type = _mapper.Map<AccountTypeDto, AccountTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        type.Accounts = new List<AccountModel>();
        _accountTypeRepository.CreateAccountType(type);
        return Ok();
    }

    [HttpGet("GetAccountTypes")]
    public IActionResult GetAccountTypes()
    {
        List<AccountTypeModel> types = _accountTypeRepository.GetAccountsTypes();

        if (types.Count <= 0)
            return NotFound();

        List<AccountTypeDto> typesDto = _mapper.Map<List<AccountTypeModel>, List<AccountTypeDto>>(types);

        return Ok(typesDto);
    }
    
    [HttpPost("CreateAccount")]
    public IActionResult CreateAccount([FromBody] AccountDto accountDto)
    {
        var account = _mapper.Map<AccountModel>(accountDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        account.Transactions = new List<TransactionModel>();
        account.Customer = _customerRepository.GetCustomer(account.CustomerId);
        account.Type = _accountTypeRepository.GetAccountTypeById(account.AccountTypeId);

        _accountRepository.CreateNewAccount(account);
        
        return Ok();
    }

    [HttpGet("GetUserAccounts/{id}")]
    public IActionResult GetUserAccounts(int id)
    {
        List<AccountModel> accounts = _accountRepository.GetUserAccount(id);

        List<GetAccountDto> accountDtos = _mapper.Map<List<AccountModel>, List<GetAccountDto>>(accounts);

        return Ok(accountDtos);

    }
}