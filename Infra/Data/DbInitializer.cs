using System.Linq;
using Domain.Models;
using Domain.Static;
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
                new Category{Description= "Transferência", Type= EntryType.Transfer},
                new Category{Description= "Compras", Type= EntryType.Debit},
                new Category{Description= "Alimentação", Type= EntryType.Debit},
                new Category{Description= "Saúde", Type= EntryType.Debit},
                new Category{Description= "Roupas", Type= EntryType.Debit},
                new Category{Description= "Lazer", Type= EntryType.Debit},
                new Category{Description= "Salário", Type= EntryType.Credit},
                new Category{Description= "Investimentos", Type= EntryType.Credit},
                new Category{Description= "Vendas", Type= EntryType.Credit},
            };

            var CurrencyTypes = new CurrencyType[]
            {
                new CurrencyType{ Description= "Dolar",  Culture= "en-US", Initials= InitialsType.USD },
                new CurrencyType{ Description= "Real",  Culture= "pt-BR", Initials= InitialsType.BRL },
                new CurrencyType{ Description= "Euro",  Culture= "es-ES", Initials= InitialsType.EUR },
                new CurrencyType{ Description= "Dolar Canadense",  Culture= "fr-CA", Initials= InitialsType.CAD },
            };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
        }
    }
}