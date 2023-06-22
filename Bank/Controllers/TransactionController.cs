using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Transaction;
using Bank.Domain.Entity.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    
    public TransactionController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("AddTransactionType")]
    public IActionResult CreateTransaction([FromBody] TransactionTypeDto typeDto)
    {
        var type = _mapper.Map<TransactionTypeDto, TransactionTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        type.Transactions = new List<TransactionModel>();
        _context.TransactionTypes.Add(type);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPost("AddTransaction")]
    public IActionResult AddTransaction([FromBody] TransactionModel transaction)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        transaction.TransactionType =
            _context.TransactionTypes.FirstOrDefault(t => t.Id == transaction.TransactionTypeId);
        transaction.Account = _context.Accounts.FirstOrDefault(a => a.Id == transaction.AccountId);
        transaction.CustomerPurchase = _context.CustomerPurchases.FirstOrDefault(p => p.Id == transaction.PurchaseId);

        _context.Transactions.Add(transaction);
        _context.SaveChanges();
        return Ok();

    }
    
}