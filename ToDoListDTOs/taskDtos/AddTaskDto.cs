using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListDTOs.taskDtos
{
    public class AddTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly DateTask { get; set; } = new DateOnly();
        public int UserId { get; set; }
    }
}
