namespace MS_Financeiro.Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);
        void Remove(long id);
        Task<T> GetById(long Id);
    }
}
