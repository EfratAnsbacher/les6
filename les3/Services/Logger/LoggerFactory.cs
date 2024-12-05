using les3.Services.Logger;

namespace les3.Services.Logger
{
    public class LoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoggerService GetLogger(int num)
        {
            if (num==1)//console
            {
                return _serviceProvider.GetRequiredService<ILoggerService>();
            }
            if (num == 2)//file
            {
                return _serviceProvider.GetRequiredService<FileLoggerService>();
            }
            else//DB
                return _serviceProvider.GetRequiredService<DBLoggerService>();
        }
    }
}
