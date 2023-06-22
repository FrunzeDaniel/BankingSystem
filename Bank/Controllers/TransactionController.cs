using AutoMapper;
using Bank.Domain;
using Bank.Domain.Dto.Transaction;
using Bank.Domain.Entity.Transactions;
using Bank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionTypeRepository _transactionTypeRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    
    public TransactionController(ITransactionRepository transactionRepository, ITransactionTypeRepository transactionTypeRepository, IAccountRepository accountRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _transactionTypeRepository = transactionTypeRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    [HttpPost("AddTransactionType")]
    public IActionResult CreateTransaction([FromBody] TransactionTypeDto typeDto)
    {
        var type = _mapper.Map<TransactionTypeDto, TransactionTypeModel>(typeDto);

        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        type.Transactions = new List<TransactionModel>();
        _transactionTypeRepository.CreateTransactionType(type);
        return Ok();
    }

    [HttpPost("AddTransaction")]
    public IActionResult AddTransaction([FromBody] TransactionModel transaction)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data!");

        transaction.TransactionType = _transactionTypeRepository.GetTransactionTypeById(transaction.TransactionTypeId);
        transaction.Account = _accountRepository.GetAccountById(transaction.AccountId);
        transaction.CustomerPurchase = _context.CustomerPurchases.FirstOrDefault(p => p.Id == transaction.PurchaseId);

        _transactionRepository.CreateTransaction(transaction);
        return Ok();

    }
    
}