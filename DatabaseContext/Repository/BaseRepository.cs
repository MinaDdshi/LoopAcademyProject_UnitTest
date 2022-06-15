using LoopAcademyProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoopAcademyProject.DatabaseContext.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> Select(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<List<TEntity>> SelectAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
