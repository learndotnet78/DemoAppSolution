using AutoMapper;
using DemoCoreAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        [HttpGet]
        public UserModel GetUsers()
        {
            User user = new User();
            UserModel userModel = new UserModel();

            user.UserID = 1;
            user.City = "NYC";
            user.UserName = "Jeff";

            //user.Add(new User()
            //{
            //    UserID = 2,
            //    Location = "SFO",
            //    UserName = "Alex"
            //});

            //user.Add(new User()
            //{
            //    UserID = 3,
            //    Location = "DC",
            //    UserName = "Jean"
            //});

            userModel = this._mapper.Map<UserModel>(user);

            return userModel;
        }
    }
}
