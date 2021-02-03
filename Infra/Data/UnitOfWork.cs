using System;
using Domain.Models;

namespace Infra.Data
{
  public class UnitOfWork : IDisposable
  {
    private ApplicationContext context = new ApplicationContext();
    private GenericRepository<Account> accountRepository;
    private GenericRepository<User> userRepository;
    private GenericRepository<Category> categoryRepository;
    private GenericRepository<FinancialTransaction> financialTransactionRepository;

    public GenericRepository<Account> AccountRepository
    {
      get
      {
        if (this.accountRepository == null)
        {
          this.accountRepository = new GenericRepository<Account>(context);
        }
        return accountRepository;
      }
    }

    public GenericRepository<User> UserRepository
    {
      get
      {

        if (this.userRepository == null)
        {
          this.userRepository = new GenericRepository<User>(context);
        }
        return userRepository;
      }
    }

    public GenericRepository<Category> CategoryRepository
    {
      get
      {
        if (this.categoryRepository == null)
        {
          this.categoryRepository = new GenericRepository<Category>(context);
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
          this.financialTransactionRepository = new GenericRepository<FinancialTransaction>(context);
        }
        return financialTransactionRepository;
      }
    }

    public void Save()
    {
      context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
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