using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListDTOs.taskDtos
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateOnly DateTask { get; set; } = new DateOnly();

        public bool IsDone { get; set; }

        public string TaskOfUser { get; set; } = null!;
    }
}
