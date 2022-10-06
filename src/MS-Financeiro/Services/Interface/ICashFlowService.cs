using MS_Financeiro.Dto;
using MS_Financeiro.Models;

namespace MS_Financeiro.Services.Interface
{
    public interface ICashFlowService
    {
        void Add(CashFlowDto obj);
        void Remove(long id);
        Task<CashFlowModel> GetById(long Id);
    }
}
