using fullwood.domain.Entities;

namespace fullwood.repository.CowRepository
{
    public interface ICowRepository<T> where T : Cow
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> Search(string query);

    }
}
