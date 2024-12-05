using les3.Models;

namespace les3.Repositories
{
    public class ProjectRepository:IProjectRepository
    {

        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Projects project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Projects? project = _context.Projects.Find(id);

            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public List<Projects> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Projects GetById(int id)
        {
            Projects? project = _context.Projects.Find(id);
            return project;
        }

        public void Update(Projects project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
