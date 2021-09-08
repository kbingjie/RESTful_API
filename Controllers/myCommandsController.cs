using Microsoft.AspNetCore.Mvc;
using myCommander.Data;
using myCommander.Models;
using System.Collections.Generic;
using myCommander.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

//A controller determines what response to send back to a user when a user makes a browser request
namespace myCommander.Contronllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class myCommandsController : ControllerBase
    {
        private readonly ImyCommanderRepo _repository;
        private readonly IMapper _mapper;
        public myCommandsController(ImyCommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        // these two endpoints are going to respond to HTTP GET request 
        ////respond to GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            // map is used to hide the "platform" part from user
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommandById")]//give us a route, GET api/commands{id}
        public ActionResult<myCommand> GetCommandById(int id)
        {
            var commandItems = _repository.GetCommandById(id);
            if (commandItems != null)
            {
                return Ok(commandItems);

            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDtp)
        {
            var commandModel = _mapper.Map<myCommand>(commandCreateDtp);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //after creation,need to pass back the location as well; for detail look up ms explain
            return CreatedAtRoute(nameof(GetCommandById), new { Id = CommandReadDto.Id }, CommandReadDto);
            //return Ok(CommandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}   partial update
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


    }
}