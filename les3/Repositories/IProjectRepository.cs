using les3.Models;

namespace les3.Repositories
{
    public interface IProjectRepository
    {
        List<Projects> GetAll();
        Projects GetById(int id);
        void Add(Projects project);
        void Update(Projects project);
        void Delete(int id);
   
    }
}