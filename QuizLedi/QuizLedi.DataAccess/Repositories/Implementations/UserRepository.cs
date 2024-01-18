using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextQuiz _db;

        public UserRepository(DbContextQuiz db)
        {
            _db = db;
        }

        public async Task<User> AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
