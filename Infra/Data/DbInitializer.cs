using System.Linq;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if(context.Categories.Any()) return;

            var categories = new Category[]
            {
                new Category{Description= "Transferência", Type= FinancialTransactionType.Transfer},
                new Category{Description= "Compras", Type= FinancialTransactionType.Debit},
                new Category{Description= "Alimentação", Type= FinancialTransactionType.Debit},
                new Category{Description= "Saúde", Type= FinancialTransactionType.Debit},
                new Category{Description= "Roupas", Type= FinancialTransactionType.Debit},
                new Category{Description= "Lazer", Type= FinancialTransactionType.Debit},
                new Category{Description= "Salário", Type= FinancialTransactionType.Credit},
                new Category{Description= "Investimentos", Type= FinancialTransactionType.Credit},
                new Category{Description= "Vendas", Type= FinancialTransactionType.Credit},
            };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
        }
    }
}