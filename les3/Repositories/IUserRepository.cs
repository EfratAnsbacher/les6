using les3.Models;
using Microsoft.EntityFrameworkCore;

namespace les3.Repositories
{
    public interface IUserRepository
    {
        List<Users> GetAll();
        Users GetById(int id);
        void Add(Users user);
        void Update(Users user);
        void Delete(int id);
    }
}
