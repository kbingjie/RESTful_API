using System.Collections.Generic;
using System.Linq;
using myCommander.Models;
using System;

namespace myCommander.Data
{
    public class SqlCommanderRepo : ImyCommanderRepo
    {

        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;

        }

        public void CreateCommand(myCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);

        }

        public IEnumerable<myCommand> GetAllCommands()
        {
            return _context.Commands.ToList();

        }

        public myCommand GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(myCommand cmd)
        {
            //nothing
        }
        public void DeleteCommand(myCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);

        }
    }
}