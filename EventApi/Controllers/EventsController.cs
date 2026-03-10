using EventApi.Interfaces;
using EventApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            var events = _eventService.GetAll();

            return Ok(events);
        }


        [HttpGet("{id:int}")]
        public ActionResult<Event> GetById(int id)
        {
            var ev = _eventService.GetById(id);
            if (ev == null) return NotFound();
            return Ok(ev );
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDto eventDto)
        {

            if (!TryValidateModel(eventDto))
            {
                return BadRequest(ModelState);
            }

            if (eventDto.EndAt <= eventDto.StartAt)
            {
                ModelState.AddModelError("EndAt", "Дата окончания должна быть позже даты начала");
                return BadRequest(ModelState);
            }

            var newEvent = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                StartAt = eventDto.StartAt,
                EndAt = eventDto.EndAt
            };

            var created = _eventService.CreateEvent(newEvent);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, EventDto eventDto)
        {

            if (!TryValidateModel(eventDto))
            {
                return BadRequest(ModelState);
            }

            var updatedEvent = new Event
            {
                Id = id,
                Title = eventDto.Title,
                Description = eventDto.Description,
                StartAt = eventDto.StartAt,
                EndAt = eventDto.EndAt
            };


            if (_eventService.Update(id, updatedEvent))
            {
                return NoContent();
            }
            else return NotFound();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_eventService.Delete(id))
            {
                return NoContent();
            }
            else return NotFound();
            
        }
    }
}
