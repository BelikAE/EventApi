using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<int>> GetAllEvent()
        {
            //Получаем все номера зданий из коллекции
            return ;
        }


        [HttpGet("{index:int}")]
        public ActionResult<List<int>> GetEventByIndex()
        {
            //Получаем все номера зданий из коллекции
            return;
        }

        [HttpPost]
        public IActionResult Post(int building)
        {
            //Добавляем номер здания в коллекцию
            _buildingsService.AddBuilding(building);
            //Возвращаем HTTP 201 Created
            return new CreatedResult();
        }


        [HttpPut("{index:int}")]
        public IActionResult Put(int index, int building)
        {
            //Меняем номер дома в коллекции по индексу
            _buildingsService.ChangeBuilding(index, building);
            //Возвращаем HTTP 204 No Content
            return new NoContentResult();
        }

        [HttpDelete("{index:int}")]
        public IActionResult Delete(int building)
        {
            //Удаляем номер дома из коллекции
            _buildingsService.RemoveBuilding(building);
            //Возвращаем HTTP 200 OK
            return new OkResult();
        }
    }
}
