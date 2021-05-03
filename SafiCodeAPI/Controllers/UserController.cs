using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafiCodeAPI.Modal.Modal;
using SafiCodeAPI.Modals;
using SafiCodeAPI.Business;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace SafiCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            this._mapper = mapper;
            this._userService = userService;
        }


        //GET api/User/GetAll

       [HttpGet]
       [Route("GetAll")]
        public async Task<IEnumerable<UserTypeViewModal>> GetAll()
        {

            var result = await _userService.GetAll();
           return _mapper.Map<IEnumerable<TblUserType>, IEnumerable<UserTypeViewModal>>(result);
        }
        // GET: api/User/Get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/User/Login
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var obj = _userService.Authenticate(model.EmailID, model.Password);
                return Ok(APIResponse.ResponseFormate(obj, (int)APIResponse.StatusCodeMessage.OK));
            }
            catch(AppException ex)
            {
                return BadRequest(APIResponse.ResponseFormate(ex,(int)APIResponse.StatusCodeMessage.OK,ex.Message));
            }
             
        }

        // POST: api/User/Register
        [HttpPost]
        [Route("register")]
        public IActionResult register([FromBody] UserViewmodal model)
        {
            var user = _mapper.Map<TblUsers>(model);
            try
            {
               var obj= _userService.Create(user, model.Password);

                
                return Ok(APIResponse.ResponseFormate(obj, (int)APIResponse.StatusCodeMessage.OK));
            }
            catch (AppException ex)
            {
                return BadRequest(APIResponse.ResponseFormate(ex, (int)APIResponse.StatusCodeMessage.OK, ex.Message));
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
