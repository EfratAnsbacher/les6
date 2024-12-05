using les3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using les3.Services.Logger;

namespace les3.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private string _filePath = "logs.txt";
        private readonly AppDbContext _context;
        private readonly les3.Services.Logger.LoggerFactory _LoggerFactory;
        private ILoggerService _logger;

        public TaskRepository(AppDbContext context, les3.Services.Logger.LoggerFactory loggerFactory)
        {
            _context = context;
            _LoggerFactory = loggerFactory;
        }
        public string Add(Tasks task)
        {
         
            var userExists = _context.Users.Find(task.UserId);
            if (userExists == null)
                return "User does not exist";

            // Validate Project
            var projectExists = _context.Projects.Find(task.ProjectId);
            if (projectExists == null)
                return "Project does not exist";

            _context.Tasks.Add(task);
            _context.SaveChanges();
            _logger = _LoggerFactory.GetLogger(3);//sending number 1/2/3 to the logger factory
            _logger.Log("המשימה נוספה בהצלחה");
            return "task created successfuly";

        }

        public void logIntoDB(string message)
        {
            Messages newMassage = new Messages();
            newMassage.Description = message;
            newMassage.Update_Date = DateTime.Now;
            _context.Messages.Add(newMassage);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tasks? task = _context.Tasks.Find(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Tasks> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Tasks GetById(int id)
        {
            Tasks? task = _context.Tasks.Find(id);
            return task;
        }

        public void Update(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public List<Tasks> GetTasksByUser(int userId)
        {
            var tasks = _context.Tasks.Where(x => x.UserId == userId);
            if (tasks == null)
                return new List<Tasks>();
            return tasks.ToList();
        }

        public List<Tasks> GetTasksByProject(int projectId)
        {
            var projects = _context.Tasks.Where(x => x.ProjectId == projectId);
            if (projects == null)
                return new List<Tasks>();
            return projects.ToList();
        }

    }
}
