using les3.Models;
using les3.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace les3.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public List<Tasks> GetTasks()
        {
            var allTasks = _taskRepository.GetAll();
            return allTasks;
        }

        public void AddTask(Tasks newTask)
        {
            _taskRepository.Add(newTask);
        }

        public Tasks GetTaskById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void UpdateTask(Tasks task)
        {
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }

        public List<Tasks> GetTasksByUser(int userId)
        {
            return _taskRepository.GetTasksByUser(userId);
        }

        public List<Tasks> GetTasksByProject(int projectId)
        {
            return _taskRepository.GetTasksByProject(projectId);
        }
    }
}
