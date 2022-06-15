using LoopAcademyProject.Entities;

namespace LoopAcademyProject.DatabaseContext.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task Insert(TEntity entity);
        Task<TEntity> Select(int Id);
        Task<List<TEntity>> SelectAll();
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
