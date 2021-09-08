using Microsoft.EntityFrameworkCore;
using myCommander.Models;

namespace myCommander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        public DbSet<myCommand> Commands { get; set; }
    }
}