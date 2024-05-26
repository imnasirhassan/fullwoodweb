using fullwood.domain.Entities;
using fullwood.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace fullwood.repository.CowRepository
{
    public class CowRepository<T> : ICowRepository<T> where T : Cow
    {
        private readonly FullwoodDbContext _context;
        private readonly DbSet<T> entities;

        public CowRepository(FullwoodDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            entities.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Task.FromResult(entities.FirstOrDefault(x => x.Id == id));
        }

        public async Task<int> Update(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await GetById(id);

            entities.Remove(entity);
            _context.SaveChanges();

            return 1;
        }

        public async Task<IEnumerable<T>> Search(string query)
        {
            var result = entities.Where(x => x.CowName.Contains(query, StringComparison.CurrentCultureIgnoreCase));

            return await Task.FromResult(result.ToList());
        }
    }
}
