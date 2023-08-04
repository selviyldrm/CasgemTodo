using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoListProject.DAL.Concrete;
using ToDoListProject.DAL.Entities;
using ToDoListProject.MediatorPattern.Commands;
using ToDoListProject.MediatorPattern.Handlers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoListProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetEventQueryHandler _getEventQueryHandler;
        private readonly CreateEventCommandHandler _createEventCommandHandler;
        private readonly RemoveEventCommandHandler _removeEventCommandHandler;

        public DefaultController(GetEventQueryHandler getEventQueryHandler, CreateEventCommandHandler createEventCommandHandler, RemoveEventCommandHandler removeEventCommandHandler)
        {
            _getEventQueryHandler = getEventQueryHandler;
            _createEventCommandHandler = createEventCommandHandler;
            _removeEventCommandHandler = removeEventCommandHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  JsonResult GetEvents() 
        { 
            var values = _getEventQueryHandler.Handle();           
            return new JsonResult(values);

        }

        [HttpPost]
        public JsonResult SaveEvent(CreateEventCommand createEventCommand)
        {       
            var status = true;
            _createEventCommandHandler.Handle(createEventCommand);
            return new JsonResult(status);
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            _removeEventCommandHandler.Handle(eventID);
            return new JsonResult(true);
        }
    }
}
