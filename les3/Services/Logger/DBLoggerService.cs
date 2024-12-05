using les3.Repositories;
using les3.Services.Logger;

namespace les3.Services.Logger
{
    public class DBLoggerService: ILoggerService
    {
        private readonly ITaskRepository _TasksRepository;
        public DBLoggerService(ITaskRepository tasksRepository)
        {
            _TasksRepository = tasksRepository;
        }

        public void Log(string message)
        {
            try
            {
                _TasksRepository.logIntoDB(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to log message: {ex.Message}");
            }
        }
    }
}
