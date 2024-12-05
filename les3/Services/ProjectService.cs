using les3.Models;
using les3.Repositories;

namespace les3.Services
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public List<Projects> GetProjects()
        {
            var allProjects = _projectRepository.GetAll();
            return allProjects;
        }

        public void AddProject(Projects newProject)
        {
            _projectRepository.Add(newProject);
        }

        public Projects GetProjectById(int id)
        {
            return _projectRepository.GetById(id);
        }

        public void UpdateProject(Projects project)
        {
            _projectRepository.Update(project);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.Delete(id);
        }
    }
}
