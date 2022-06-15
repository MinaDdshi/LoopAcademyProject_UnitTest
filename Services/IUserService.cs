using LoopAcademyProject.Entities;

namespace LoopAcademyProject.Services
{
    public interface IUserService
    {
        Task Create(User create);
        Task<User> Read(int Id);
        Task<List<User>> ReadAll();
        Task Update(User update);
        Task Delete(int Id);
    }
}
