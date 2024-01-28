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

        [HttpPut(template:"{userId}/image")]
        public async Task<IActionResult> UpdateImage(Guid userId, [FromForm] IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var userImage = UserFakeDB.UserImages
                .FirstOrDefault(userImage => userImage.UserId == userId);

            if(userImage is null)
            {
                UserFakeDB.UserImages.Add(new UserImage(userId, image:memoryStream.ToArray()));
            } else
            {
                userImage.UpdateImage(memoryStream.ToArray());
            }

            return Ok(new { message = "Upload Completed!" });
        }

        [HttpGet(template:"{userId}/image")]
        public IActionResult GetUserImage(Guid userId) 
        {
            var userImage = UserFakeDB.UserImages
               .FirstOrDefault(userImage => userImage.UserId == userId);

            if(userImage is null)
            {
                return NotFound();
            }

            return File(userImage.Image, contentType: "image/png");
        }
    }
}
