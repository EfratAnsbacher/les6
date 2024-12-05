using les3.Models;
using System.Threading.Tasks;

namespace les3.Services
{
    public interface IUserService
    {
        List<Users> GetUsers();
        Users GetUserById(int id);
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
