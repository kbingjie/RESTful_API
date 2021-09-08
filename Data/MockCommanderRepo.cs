
using System.Collections.Generic;
using myCommander.Models;

namespace myCommander.Data
{
    public class MockCommanderRepo : ImyCommanderRepo
    {
        public void CreateCommand(myCommand cmd)
        {
            throw new System.NotImplementedException();
        }
        public void UpdateCommand(myCommand cmd)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteCommand(myCommand cmd)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<myCommand> GetAllCommands()
        {
            var commands = new List<myCommand>
            {
                new myCommand{Id = 0, HowTo = "Boil an egg", Line = "Boild water", Platform = "Kettle and pan"},
                new myCommand{Id = 1, HowTo = "different one", Line = "Boild water", Platform = "Kettle and pan"},
                new myCommand{Id = 2, HowTo = "Bwhat else", Line = "hahah water", Platform = "Kettle and pan"}

            };

            return commands;
        }

        public myCommand GetCommandById(int id)
        {
            return new myCommand { Id = 0, HowTo = "Boil an egg", Line = "Boild water", Platform = "Kettle and pan" };
        }
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

    }
}