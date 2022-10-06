using MS_Financeiro.Context;
using MS_Financeiro.Repository.Interface;

namespace MS_Financeiro.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly FinancialContext _financialContext;

        public RepositoryBase(FinancialContext FinancialContext)
        {
            _financialContext = FinancialContext;
        }

        public void Add(T obj)
        {
            try
            {
                _financialContext.Set<T>().Add(obj);
                _financialContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message", ex);
            }
        }

        public async Task<T> GetById(long Id)
        {
            return await _financialContext.Set<T>().FindAsync(Id);
        }

        public void Remove(long Id)
        {
            try
            {
                var regDel = _financialContext.Set<T>().Find(Id);
                _financialContext.Remove(regDel);
                _financialContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
        }
    }
}
