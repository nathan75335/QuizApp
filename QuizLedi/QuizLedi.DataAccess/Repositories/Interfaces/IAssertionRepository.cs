using QuizLedi.DataAccess.Entities;

namespace QuizLedi.DataAccess.Repositories.Interfaces
{
    public interface IAssertionRepository
    {
        Task<List<Assertion>> GetAllAssertionAsync();
        Task<Assertion> GetAssertionByIdAsync(int id);
        Task<Assertion> AddAsync(Assertion assertion);
        Task<Assertion> UpdateAsync(Assertion assertion);
        Task<Assertion> DeleteAsync(Assertion assertion);
    }
}
