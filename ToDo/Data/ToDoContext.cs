using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.modells;

namespace ToDo.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext (DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo.modells.adminUsers> adminUsers { get; set; } = default!;
        public DbSet<ToDo.modells.users> users { get; set; } = default!;
        public DbSet<ToDo.modells.tasks> tasks { get; set; } = default!;
        public DbSet<ToDo.modells.taskList> taskList { get; set; } = default!;
    }
}
