namespace fullwood.services.CowService
{
    public interface ICowService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<T> GetById(int id);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> Search(string query);
    }
}
