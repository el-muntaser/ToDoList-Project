using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDTOs.taskDtos;

namespace ToDoListBAL.TaskServices
{
    public interface ITaskServices
    {
        public Task<List<TaskDto?>> GetAllTasks();
        public Task<List<TaskDto?>> GetAllTasksByUserId(int userId);
        public Task<TaskDto?> GetTaskById(int taskId);
        public Task<List<TaskDto?>> getAllDoneTasks();
        public Task<List<TaskDto?>> GetAllActiveTasks();
        public Task<int> CountTasks();
        public Task<int> CountDoneTasks();
        public Task<int> CountActiveTasks();
        public Task<TaskDto?> AddTask(AddTaskDto task);
        public Task<TaskDto?> UpdateTask(UpdateTaskDto task);
        public Task<bool> DeleteTask(int taskId);

    }
}
