using Api___clone_wpp.FakeDB;
using Microsoft.AspNetCore.Mvc;

namespace Api___clone_wpp.Controllers
{
    [ApiController, Route(template: "api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(UserFakeDB.Users);
        }
    }
}
