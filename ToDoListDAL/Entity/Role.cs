using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListDAL.Entity
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        public List<User> users { get; set; } = null!;
    }
}
