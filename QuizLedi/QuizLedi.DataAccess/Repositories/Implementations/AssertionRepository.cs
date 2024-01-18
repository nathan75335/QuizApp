using Microsoft.EntityFrameworkCore;
using QuizLedi.DataAccess.Data;
using QuizLedi.DataAccess.Entities;
using QuizLedi.DataAccess.Repositories.Interfaces;

namespace QuizLedi.DataAccess.Repositories.Implementations
{
    public class AssertionRepository : IAssertionRepository
    {
        private readonly DbContextQuiz _db;
        public AssertionRepository(DbContextQuiz db) 
        {
            _db = db;
        }
        public async Task<Assertion>AddAsync(Assertion assertion)
        {
            _db.Assertions.Add(assertion);
            await _db.SaveChangesAsync();

            return assertion;
        }

        public async Task<Assertion>DeleteAsync(Assertion assertion)
        {
            _db.Assertions.Remove(assertion);
            await _db.SaveChangesAsync();

            return assertion;
        }

        public async Task<List<Assertion>>GetAllAssertionAsync()
        {
            return await _db.Assertions.AsNoTracking().ToListAsync();
        }

        public async Task<Assertion>GetAssertionByIdAsync(int id)
        {
            return await _db.Assertions.AsNoTracking().FirstOrDefaultAsync(a =>a.Id==id);
        }

        public async Task<Assertion>UpdateAsync(Assertion assertion)
        {
            _db.Assertions.Update(assertion);
            await _db.SaveChangesAsync();

            return assertion;
        }
    }
}
