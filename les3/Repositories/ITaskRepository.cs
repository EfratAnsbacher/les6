using les3.Models;

namespace les3.Repositories
{
    public interface ITaskRepository
    {
        List<Tasks> GetAll();
        Tasks GetById(int id);
        string Add(Tasks task);
        void Update(Tasks task);
        void Delete(int id);
        List<Tasks> GetTasksByUser(int userId);
        List<Tasks> GetTasksByProject(int projectId);
        void logIntoDB(string message);
    }
}
