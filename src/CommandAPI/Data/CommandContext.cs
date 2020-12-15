using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI.Data
{
    public class CommandContext : DbContext// DbContext class as a representation of the database
    {
        public CommandContext(DbContextOptions<CommandContext> options):base(options)
        {

        }
        public DbSet<Command> CommandItems{get;set;}//DbSet as a representation of a table in the database
        //tell DbSet that we want to 'model' our Commands in the DB(as a table)
    }
}