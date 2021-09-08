using System.Collections.Generic;
using myCommander.Models;

namespace myCommander.Data
{
    public interface ImyCommanderRepo
    {
        bool SaveChanges();
        IEnumerable<myCommand> GetAllCommands();
        myCommand GetCommandById(int id);
        void CreateCommand(myCommand cmd);
        void UpdateCommand(myCommand cmd);
        void DeleteCommand(myCommand cmd);

    }
}