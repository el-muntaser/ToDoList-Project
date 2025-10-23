using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBAL.TaskServices;
using ToDoListDAL.Entity;
using ToDoListDTOs.taskDtos;

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManageController : ControllerBase
    {
        readonly private ITaskServices _TaskServices;

        public TaskManageController(ITaskServices taskServices)
        {
            _TaskServices = taskServices;
        }

        [HttpPost("AddNewTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TaskDto>> AddNewTask([FromBody]AddTaskDto addTaskDto)
        {

            if (addTaskDto == null)
            {
                return BadRequest();
            }
            var NewTask = await _TaskServices.AddTask(addTaskDto);
            if (NewTask == null)
            {
                return BadRequest();
            }
            return Ok(NewTask);
        }

        [HttpGet("CountActiveTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> CountActiveTasks()
        {
            int count = await _TaskServices.CountActiveTasks();

            return Ok(count);
        }


        [HttpGet("CountDoneTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<int>> CountDoneTasks()
        {
            int count = await _TaskServices.CountDoneTasks();

            return Ok(count);
        }


        [HttpGet("CountTasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<int>> CountTasks()
        {
            int count = await _TaskServices.CountTasks();

            return Ok(count);
        }

        [HttpDelete("DeleteTask{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<bool>> DeleteTask(int taskId) 
        {
            if(taskId <= 0)
            {
                return BadRequest();
            }

            bool IsDeleted = await _TaskServices.DeleteTask(taskId);
            return Ok(IsDeleted);
        }

        [HttpGet("GetAllActiveTasks")]
        public async Task<ActionResult<List<TaskDto>>> GetAllActiveTasks()
        {
            var tasks = await _TaskServices.GetAllActiveTasks();

            return Ok(tasks);
        }

        [HttpGet("getAllDoneTasks")]
        public async Task<ActionResult<List<TaskDto>>> getAllDoneTasks()
        {
            var tasks = await _TaskServices.getAllDoneTasks();

            return Ok(tasks);
        }

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasks()
        {
            var tasks = await _TaskServices.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet("GetAllTasksByUserId{userId}")]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasksByUserId(int userId)
        {
            var tasks = await _TaskServices.GetAllTasksByUserId(userId);

            return Ok(tasks);
        }

        [HttpGet("GetTaskById{taskId}")]
        public async Task<ActionResult<TaskDto>> GetTaskById(int taskId)
        {
            var task = await _TaskServices.GetTaskById(taskId);
            if (task is null)
                return NotFound("this task is not found");

            return Ok(task);
        }

        [HttpPut("UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskDto>> UpdateTask(UpdateTaskDto task)
        {
            if (task is null)
                return BadRequest();

            var taskUpdated = await _TaskServices.UpdateTask(task);
            return Ok(taskUpdated);
        }

 
    }
}
