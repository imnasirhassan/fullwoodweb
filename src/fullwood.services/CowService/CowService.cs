using fullwood.domain.Entities;
using fullwood.repository.CowRepository;

namespace fullwood.services.CowService
{
    public class CowService(ICowRepository<Cow> repository) : ICowService<Cow>
    {
        private readonly ICowRepository<Cow> _repository = repository;

        public async Task<int> Add(Cow entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Cow>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Cow> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> Update(Cow entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<IEnumerable<Cow>> Search(string query)
        {
            return await _repository.Search(query);
        }
    }
}
