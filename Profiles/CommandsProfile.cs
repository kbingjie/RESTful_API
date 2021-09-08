using AutoMapper;
using myCommander.Dtos;
using myCommander.Models;

namespace myCommander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // source -> Target
            CreateMap<myCommand, CommandReadDto>();
            CreateMap<CommandCreateDto, myCommand>();
            CreateMap<CommandUpdateDto, myCommand>();
            CreateMap<myCommand, CommandUpdateDto>();
        }

    }
}

