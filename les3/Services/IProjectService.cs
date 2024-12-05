using les3.Models;

namespace les3.Services
{
    public interface IProjectService
    {
        List<Projects> GetProjects();
        Projects GetProjectById(int id);
        void AddProject(Projects project);
        void UpdateProject(Projects project);
        void DeleteProject(int id);
    }
}
