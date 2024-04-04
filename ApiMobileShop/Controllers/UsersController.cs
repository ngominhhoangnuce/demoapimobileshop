using ApiMobileShop.Data;
using ApiMobileShop.Models;
using ApiMobileShop.Reponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobileShop.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usershop;

        public UserController(IUsersRepository usershop)
        {
            _usershop = usershop;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            var users = _usershop.GetUsers();
            return Ok(users);
        }

        [HttpGet("{UserId}")]
        public ActionResult<UserModel> GetUserById(int UserId)
        {
            var usermodel = _usershop.GetUserById(UserId);

            if (usermodel == null)
            {
                return NotFound();
            }

            return Ok(usermodel);
        }

        [HttpPost("Add")]
        public ActionResult AddUser([FromBody] User usermodel)
        {
            if (usermodel == null || usermodel.UserId <= 0)
            {
                return BadRequest();
            }

            _usershop.AddUser(usermodel);

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult UpdateUser([FromBody] User usermodel)
        {
            if (usermodel == null || usermodel.UserId <= 0)
            {
                return BadRequest();
            }

            _usershop.UpdateUser(usermodel);

            return Ok();
        }

        [HttpDelete("{UserId}")]
        public ActionResult DeleteUser(int UserId)
        {
            _usershop.DeleteUser(UserId);

            return Ok();
        }
    }
}
