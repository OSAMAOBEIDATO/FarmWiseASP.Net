using AutoMapper;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using DTOS.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FarmWiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FarmWiseDBContext dBContext;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOFWork;

        public UserController(FarmWiseDBContext farmWiseDBContext,IMapper mapper,IUnitOfWork unitOFWork)
        {
            this.dBContext=farmWiseDBContext;
            this.mapper=mapper;
            this.unitOFWork=unitOFWork;
        }


        [HttpGet("{id:guid}", Name = "GetUserById")]
        public IActionResult GetUserbyIdAsync(Guid id)
        {
            var userDomain =  unitOFWork.Users.Get(u => u.Id == id);
            if (userDomain==null)
            {
                return NotFound("User Not Found");
            }
            var userDTO = mapper.Map<UserDTO>(userDomain);
            return Ok(userDTO);
        }



        [HttpGet]
        public IActionResult GetAllUserasync()
        {
            var UsersDomain =  unitOFWork.Users.GetAll();
            if (UsersDomain == null)
            {
                return NotFound("There are no Users");
            }

            var UsersDTO = mapper.Map<List<UserDTO>>(UsersDomain);
            return Ok(UsersDTO);
        }


        [HttpPost]
        public IActionResult AddUserAsync([FromBody] AddUserRequest addUserRequest)
        {
            if (addUserRequest==null)
            {
                return BadRequest("Invalid user data.");
            }
            var UserDomain = mapper.Map<User>(addUserRequest);

            unitOFWork.Users.Add(UserDomain);
            unitOFWork.Save();

            var userDTO = mapper.Map<UserDTO>(UserDomain);

            return CreatedAtAction("GetUserById", new { id = userDTO.Id }, userDTO); 


        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdataUserIformation(Guid id, [FromBody] UpdataUserRequest updataUserRequest)
        {
            var UserDomain =  unitOFWork.Users.Get(a => a.Id==id);
            if (UserDomain==null)
            {
                return NotFound("User Not Found");
            }

            UserDomain.BirthDate=updataUserRequest.BirthDate;
            UserDomain.Email=updataUserRequest.Email;
            UserDomain.Location=updataUserRequest.Location;
            UserDomain.Name=updataUserRequest.Name;
            UserDomain.PictureProfile=updataUserRequest.PictureProfile;
            
             unitOFWork.Users.Update(UserDomain);
             unitOFWork.Save();

            var userDTO = mapper.Map<UserDTO>(UserDomain);

            return Ok(userDTO);
        }



        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var userDomain = unitOFWork.Users.Get(a => a.Id==id);
            if (userDomain==null)
            {
                return NotFound("User Not Found");
            }
            var userDTO = mapper.Map<UserDTO>(userDomain);
            //var userDTO = new UserDTO()

            unitOFWork.Users.Remove(userDomain);
            unitOFWork.Save();

            return Ok(userDTO);
        }
    }
}
