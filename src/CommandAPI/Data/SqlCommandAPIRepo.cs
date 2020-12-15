using System.Collections.Generic;
using CommandAPI.Models;
using System.Linq;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        //use Constructor Dependency Injection to inject our DB Context into our SqlCommandAPIRepo class
        private readonly CommandContext _context;
        public SqlCommandAPIRepo (CommandContext context) //A DB Context instance is injected in via our constructor (as context).
        {
            _context = context;// assign context to a private read-only field (_context) that we can use in the rest of the SqlCommandAPIRepo class.
        }
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
             return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
           return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}