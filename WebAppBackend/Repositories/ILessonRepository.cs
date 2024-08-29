using WebAppBackend.Models;

namespace WebAppBackend.Repositories;

public interface ILessonRepository : IRepository<Lesson>
{
    Task<IEnumerable<Lesson>> GetLessonsForTrainingBootcamp(int trainingBootcampId);
}