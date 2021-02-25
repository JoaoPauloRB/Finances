using System;
using Domain.Models;
using Infra.Data.Repositories;

namespace Infra.Data
{
  public class UnitOfWork : IDisposable
  {
    private ApplicationContext _context;
    private GenericRepository2<Account> accountRepository;
    private GenericRepository<Category> categoryRepository;
    private GenericRepository<FinancialTransaction> financialTransactionRepository;
    private GenericRepository<User> userRepository;

    public UnitOfWork(ApplicationContext context) {
      _context = context;
    }

    public GenericRepository2<Account> AccountRepository
    {
      get
      {
        if (this.accountRepository == null)
        {
          this.accountRepository = new GenericRepository2<Account>(_context);
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

    public GenericRepository<FinancialTransaction> FinancialTransactionRepository
    {
      get
      {
        if (this.financialTransactionRepository == null)
        {
          this.financialTransactionRepository = new GenericRepository<FinancialTransaction>(_context);
        }
        return financialTransactionRepository;
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