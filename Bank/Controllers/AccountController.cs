using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Account;
using Bank.Domain.Entity.Account;
using Bank.Domain.Entity.Transactions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AccountController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("AddAccountType")]
    public IActionResult AddAccountType([FromBody]AccountTypeDto typeDto)
    {
        var type = _mapper.Map<AccountTypeDto, AccountTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        type.Accounts = new List<AccountModel>();
        _context.AccountTypes.Add(type);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("GetAccountTypes")]
    public IActionResult GetAccountTypes()
    {
        List<AccountTypeModel> types = _context.AccountTypes.ToList();

        if (types.Count <= 0)
            return NotFound();

        List<AccountTypeDto> typesDto = _mapper.Map<List<AccountTypeModel>, List<AccountTypeDto>>(types);

        return Ok(typesDto);
    }
    
    [HttpPost("CreateAccount")]
    public IActionResult CreateAccount([FromBody] AccountDto accountDto)
    {
        var account = _mapper.Map<AccountDto, AccountModel>(accountDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");
        
        account.Transactions = new List<TransactionModel>();
        account.Customer = _context.Customers.FirstOrDefault(c => c.Id == account.CustomerId);
        account.Type = _context.AccountTypes.FirstOrDefault(t => t.Id == account.AccountTypeId);

        _context.Accounts.Add(account);
        _context.SaveChanges();
        
        return Ok();
    }

    [HttpGet("GetUserAccounts/{id}")]
    public IActionResult GetUserAccounts(int id)
    {
        List<AccountModel> accounts = _context.Accounts.Where(a => a.Id == id).ToList();

        List<GetAccountDto> accountDtos = _mapper.Map<List<AccountModel>, List<GetAccountDto>>(accounts);

        return Ok(accountDtos);

    }
}