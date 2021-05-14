using System;
using Domain.Models;
using Infra.Data.Repositories;

namespace Infra.Data
{
  public class UnitOfWork : IDisposable
  {
    private ApplicationContext _context;
    private GenericRepository<Account> accountRepository;
    private GenericRepository<Category> categoryRepository;
    private GenericRepository<CurrencyType> currencyType;
    private GenericRepository<LedgerEntries> ledgerEntriesRepository;
    private GenericRepository<Transaction> transactionRepository;
    private GenericRepository<User> userRepository;

    public UnitOfWork(ApplicationContext context) {
      _context = context;
    }

    public GenericRepository<Account> AccountRepository
    {
      get
      {
        if (this.accountRepository == null)
        {
          this.accountRepository = new GenericRepository<Account>(_context);
        }
        return accountRepository;
      }
    }

    public GenericRepository<Category> CategoryRepository
    {
      get
      {
        if (this.categoryRepository == null)
        {
          this.categoryRepository = new GenericRepository<Category>(_context);
        }
        return categoryRepository;
      }
    }

    public GenericRepository<CurrencyType> CurrencyTypeRepository
    {
      get
      {
        if (this.currencyType == null)
        {
          this.currencyType = new GenericRepository<CurrencyType>(_context);
        }
        return currencyType;
      }
    }

    public GenericRepository<LedgerEntries> LedgerEntriesRepository
    {
      get
      {
        if (this.ledgerEntriesRepository == null)
        {
          this.ledgerEntriesRepository = new GenericRepository<LedgerEntries>(_context);
        }
        return ledgerEntriesRepository;
      }
    }


    public GenericRepository<Transaction> TransactionRepository
    {
      get
      {
        if (this.transactionRepository == null)
        {
          this.transactionRepository = new GenericRepository<Transaction>(_context);
        }
        return transactionRepository;
      }
    }

    public GenericRepository<User> UserRepository
    {
      get
      {
        if (this.userRepository == null)
        {
          this.userRepository = new GenericRepository<User>(_context);
        }
        return userRepository;
      }
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}