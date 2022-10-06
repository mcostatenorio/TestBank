using MS_Financeiro.Context;
using MS_Financeiro.Models;
using MS_Financeiro.Repository.Interface;

namespace MS_Financeiro.Repository
{
    public class CashFlowRepository : RepositoryBase<CashFlowModel>, ICashFlowRepository
    {
        private readonly FinancialContext _financialContext;
        public CashFlowRepository(FinancialContext FinancialContext) : base(FinancialContext)
        {
            _financialContext = FinancialContext;
        }
    }
}
