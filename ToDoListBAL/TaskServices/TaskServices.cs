using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.DataRepo.taskRepo;
using ToDoListDAL.Entity;
using ToDoListDTOs.taskDtos;

namespace ToDoListBAL.TaskServices
{
    public class TaskServices : ITaskServices
    {
        readonly private ITaskRepo _taskRepo;

        public TaskServices(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public async Task<TaskDto?> AddTask(AddTaskDto task)
        {
            if(task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var NewTask = new taskEntity
            {
                Title = task.Title,
                Description = task.Description,
                DateTask = task.DateTask,
                UserId = task.UserId,
            };
           
            return await _taskRepo.AddTask(NewTask);

            
        }

        public async Task<int> CountActiveTasks()
        {
            return await _taskRepo.CountActiveTasks();
            
        }

        public async Task<int> CountDoneTasks()
        {
            return await _taskRepo.CountDoneTasks();
        }

        public async Task<int> CountTasks()
        {
            return await _taskRepo.CountTasks();
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            if (await _taskRepo.GetTaskById(taskId) != null) 
            {
                return await _taskRepo.DeleteTask(taskId);
            }
            return false;
        }

        public async Task<List<TaskDto>> GetAllActiveTasks()
        {
            var tasks = await _taskRepo.GetAllActiveTasks();
            
            return tasks.ToList();
            
            
        }

        public async Task<List<TaskDto>> getAllDoneTasks()
        {
            var tasks = await _taskRepo.GetAllDoneTasks();

            return tasks.ToList();
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            var tasks = await _taskRepo.GetAllTasks();

            return tasks.ToList();
        }

        public async Task<List<TaskDto>> GetAllTasksByUserId(int userId)
        {
            var userOfTasks = await _taskRepo.GetAllTasksByUserId(userId);
            return userOfTasks.ToList();
        }

        public async Task<TaskDto?> GetTaskById(int taskId)
        {
            var taskById = await _taskRepo.GetTaskById(taskId);
            if(taskById is not null)
                return taskById;

            return null;
        }

        public async Task<TaskDto> UpdateTask(UpdateTaskDto task)
        {
            if (task == null) {  throw new ArgumentNullException(nameof(task)); }

            var updateTask = new taskEntity
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DateTask = task.DateTask,
            };

            var newtask = await _taskRepo.UpdateTask(updateTask);
            return newtask;
            
        }
    }
}
