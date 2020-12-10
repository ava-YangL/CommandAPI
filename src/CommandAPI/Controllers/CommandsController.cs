using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController:ControllerBase
    {
        private readonly ICommandAPIRepo _repository; //cant new a Interface

        /*when the constructor is called, the DI system will inject the required dependency
        when we ask for an instance of ICommandAPIRepo*/
        public CommandsController(ICommandAPIRepo repository) //Constructor with input interface
        {
            _repository=repository;// be assigned the injected MockCommandAPIRepe 
            //repository is the injected dependency (in this case MockCommandAPIRepo)
        }


        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string [] {"this","is","hard","coded"};

        // }
        [HttpGet] //reponds to GET verb
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems); //Return a HTTP 200 Result (OK) and pass back our result set
        }
        
        [HttpGet("{id}")] 
        public ActionResult<IEnumerable<Command>> GetAllCommandsById(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem); 
        }
    }
}