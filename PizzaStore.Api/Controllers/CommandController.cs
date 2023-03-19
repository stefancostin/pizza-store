using Microsoft.AspNetCore.Mvc;
using PizzaStore.Core.Abstractions;
using PizzaStore.Core;

namespace PizzaStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly CommandRouter _router;

        public CommandController(CommandRouter router)
        {
            _router = router;
        }

        [HttpPost]
        public IActionResult PostCommand([FromBody] Command command)
        {
            _router.HandleCommand(command);
            return Ok();
        }
    }
}
