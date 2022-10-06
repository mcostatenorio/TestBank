using Microsoft.EntityFrameworkCore;
using MS_Financeiro.Models;

namespace MS_Financeiro.Context
{
    public class FinancialContext : DbContext
    {
        public FinancialContext(DbContextOptions<FinancialContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<CashFlowModel> CashFlow { get; set; }
    }
}
