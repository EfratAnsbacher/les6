using les3.Models;
using System.Threading.Tasks;

namespace les3.Services
{
    public interface ITaskService
    {
        List<Tasks> GetTasks();
        Tasks GetTaskById(int id);
        void AddTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(int id);
        List<Tasks> GetTasksByUser(int userId);
        List<Tasks> GetTasksByProject(int projectId);
    }
}
