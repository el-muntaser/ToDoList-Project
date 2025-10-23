using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Data;
using ToDoListDAL.Entity;
using ToDoListDTOs.taskDtos;

namespace ToDoListDAL.DataRepo.taskRepo
{
    public class TaskRepo : ITaskRepo
    {
        readonly private AppDbContext _DbContext;

        public TaskRepo(AppDbContext dbContext)
        {
            _DbContext = dbContext;

        }
        public async Task<TaskDto?> AddTask(taskEntity newTask)
        {
            if (newTask == null)
            {
                return null;
            }

            var task = newTask;
            await _DbContext.Tasks.AddAsync(task);
            await _DbContext.SaveChangesAsync();

            var creart = await _DbContext.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                TaskOfUser = t.User.FirstName
            }).FirstOrDefaultAsync();

            return creart;



        }

        public async Task<int> CountActiveTasks()
        {
            return await _DbContext.Tasks.Where(t => t.IsDone == false).CountAsync();
        }

        public async Task<int> CountDoneTasks()
        {
            return await _DbContext.Tasks.Where(t => t.IsDone == true).CountAsync();
        }

        public async Task<int> CountTasks()
        {
            return await _DbContext.Tasks.CountAsync();
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _DbContext.Tasks.FindAsync(id);

            if (task != null)
            {
                _DbContext.Tasks.Remove(task);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<TaskDto>> GetAllActiveTasks()
        {
            return await _DbContext.Tasks.Where(t => t.IsDone == false).Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName,
            }).ToListAsync();
        }

        public async Task<List<TaskDto>> GetAllDoneTasks()
        {
            return await _DbContext.Tasks.Where(t => t.IsDone == true).Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName,
            }).ToListAsync();
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            return await _DbContext.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName,

            }).ToListAsync();
        }

        public async Task<List<TaskDto>> GetAllTasksByUserId(int userId)
        {
            return await _DbContext.Tasks.Where(u => u.UserId == userId).Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName,
            }).ToListAsync();
        }

        public async Task<TaskDto?> GetTaskById(int id)
        {
            var user = await _DbContext.Tasks.Where(t => t.Id == id).Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName,
            }).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;

        }

        public async Task<TaskDto?> UpdateTask(taskEntity UpdateTask)
        {
            var FoundTask = await _DbContext.Tasks.FirstOrDefaultAsync(t => t.Id == UpdateTask.Id);

            if (FoundTask == null)
            {
                return null;
            }

            FoundTask.Title = UpdateTask.Title;
            FoundTask.Description = UpdateTask.Description;

            _DbContext.Update(FoundTask);
            await _DbContext.SaveChangesAsync();

            var NewTask =await _DbContext.Tasks.Where(t => t.Id == FoundTask.Id).Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateTask = t.DateTask,
                IsDone = t.IsDone,
                TaskOfUser = t.User.FirstName
            }).FirstOrDefaultAsync();


            return NewTask;


        }
    }
}
