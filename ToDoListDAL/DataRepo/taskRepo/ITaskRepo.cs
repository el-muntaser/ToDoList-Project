using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Entity;
using ToDoListDTOs.taskDtos;

namespace ToDoListDAL.DataRepo.taskRepo
{
    public interface ITaskRepo
    {
        public Task<TaskDto> AddTask(taskEntity newTask);
        public Task<TaskDto> UpdateTask(taskEntity UpdateTask);
        public Task<bool> DeleteTask(int id);
        public Task<List<TaskDto>> GetAllTasks();
        public Task<List<TaskDto>> GetAllTasksByUserId(int userId);
        public Task<TaskDto> GetTaskById(int id);
        public Task<List<TaskDto>> GetAllActiveTasks();
        public Task<List<TaskDto>> GetAllDoneTasks();
        public Task<int> CountTasks();
        public Task<int> CountActiveTasks();
        public Task<int> CountDoneTasks();
        
    }
}
