using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MS_Financeiro.Context;
using MS_Financeiro.Dto;
using MS_Financeiro.Models;
using MS_Financeiro.Repository.Interface;
using MS_Financeiro.Services.Interface;

namespace MS_Financeiro.Services
{
    public class CashFlowService : ICashFlowService
    {
        private ICashFlowRepository _cashFlowRepository;
        private IMapper _mapper;
        private readonly FinancialContext _context;

        public CashFlowService(ICashFlowRepository CashFlowRepository, IMapper Mapper, FinancialContext Context)
        {
            _cashFlowRepository = CashFlowRepository;
            _mapper = Mapper;
            _context = Context;
        }

        public void Add(CashFlowDto cashFlow)
        {
            _cashFlowRepository.Add(_mapper.Map<CashFlowModel>(cashFlow));
        }

        public async Task<CashFlowModel> GetById(long Id)
        {
            return await _cashFlowRepository.GetById(Id);
        }

        public void Remove(long id)
        {
            _cashFlowRepository.Remove(id);
        }
    }
}
