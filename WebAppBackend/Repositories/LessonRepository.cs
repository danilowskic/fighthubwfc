using Microsoft.EntityFrameworkCore;
using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public class LessonRepository : Repository<Lesson>, ILessonRepository
{
    
    public LessonRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<Lesson>> GetLessonsForTrainingBootcamp(int trainingBootcampId)
    {
        return await _dbSet
            .Where(l => l.TrainingBootcampId == trainingBootcampId)
            .OrderBy(l => l.DateTime)
            .ToListAsync();
    }
}