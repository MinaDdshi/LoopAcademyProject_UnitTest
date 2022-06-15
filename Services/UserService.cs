using LoopAcademyProject.DatabaseContext;
using LoopAcademyProject.DatabaseContext.Repository;
using LoopAcademyProject.Entities;

namespace LoopAcademyProject.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }



        public async Task Create(User create)
        {
            var user = new User
            {
                UserName = create.UserName,
                Name = create.Name,
                SurName = create.SurName,
                PhoneNumber = create.PhoneNumber,
                Birth = create.Birth,
                NationalCode = create.NationalCode,
            };

            await _userRepository.Insert(user);
        }

        public async Task<User> Read(int Id)
        {
            var user = await _userRepository.Select(Id);

            return new User
            {
                UserName = user.UserName,
                Name = user.Name,
                SurName = user.SurName,
                PhoneNumber = user.PhoneNumber,
                Birth = user.Birth,
                NationalCode = user.NationalCode,
            };
        }

        public async Task<List<User>> ReadAll()
        {
            var user = await _userRepository.SelectAll();

            return user.Select(x => new User
            {
                UserName = x.UserName,
                Name = x.Name,
                SurName = x.SurName,
                PhoneNumber = x.PhoneNumber,
                Birth = x.Birth,
                NationalCode = x.NationalCode,
            }).ToList();
        }

        public async Task Update(User update)
        {
            var user = await _userRepository.Select(update.Id);
            user.UserName = update.UserName;
            user.Name = update.Name;
            user.SurName = update.SurName;
            user.PhoneNumber = update.PhoneNumber;
            user.Birth = update.Birth;
            user.NationalCode = update.NationalCode;
            await _userRepository.Update(user);
        }

        public async Task Delete(int Id)
        {
            var user = await _userRepository.Select(Id);
            await _userRepository.Delete(user);
        }
    }
}
