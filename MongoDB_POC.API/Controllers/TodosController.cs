using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB_POC.API.Models;
using MongoDB_POC.API.Services;
using System.Configuration;
using System.Threading.Tasks;

namespace MongoDB_POC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : Controller
    {
        public string DatabaseUrl { get; private set; }
        public string DatabaseName { get; private set; }

        public TodosController(IConfiguration configuration)
        {
            DatabaseUrl = configuration.GetValue<string>("Database:Local:Url");
            DatabaseName = configuration.GetValue<string>("Database:Name");
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoDbService = new MongoDbService(DatabaseName, "Todos", DatabaseUrl);
            var allTodos = await mongoDbService.GetAllTodos();

            return Json(allTodos);
        }

        [HttpPost]
        public async Task Post([FromBody]TodoModel todo)
        {
            var mongoDbService = new MongoDbService(DatabaseName, "Todos", DatabaseUrl);
            await mongoDbService.InsertTodo(todo);
        }

        [HttpGet]
        [Route("disponibilidade")]
        public OkResult Disponibilidade()
        {
            return Ok();
        }
    }
}