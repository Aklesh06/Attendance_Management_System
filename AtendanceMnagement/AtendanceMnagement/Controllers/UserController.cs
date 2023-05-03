using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Schoolcontext _Schoolcontext;
        public UserController(Schoolcontext Schoolcontext)
        {
            this._Schoolcontext = Schoolcontext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var userDetails = await _Schoolcontext.Users.ToListAsync();
            return userDetails;
        }
        [HttpGet("api/Student")]
        public async Task<IEnumerable<User>> GetAllStudentDetails()
        {

            var userDetails = await _Schoolcontext.Users.Where(x=>x.RolesId == 1).ToListAsync();
            return userDetails;
        }
        [HttpGet("api/{userName}")]
        public async Task<IEnumerable<User>> GetCompanies(string userName)
        {
            var companies = await _Schoolcontext.Users.Where(x => x.UserName == userName).ToListAsync();
            return companies;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
       

        // POST api/<UserController>
        [HttpPost]
        public async Task<User> Post(UserDAO value)
        {
            User user = new User();
            var roles = await _Schoolcontext.Roles.FirstAsync(x => x.RolesId == value.RolesId);
            user.UserId = value.UserId;
            user.UserName = value.UserName;
            user.UserPassword = value.UserPassword;
            user.DateOfBirth = value.DateOfBirth;
            user.Gender = value.Gender;
            user.CurrentAddress = value.CurrentAddress;
            user.PermanentAddress = value.PermanentAddress;
            user.City = value.City;
            user.Nationality = value.Nationality;
            user.PinCode = value.PinCode;
            user.Email = value.Email;
            user.Phoneno = value.Phoneno;
            user.CreateDate = value.CreateDate;
            user.UpdatedDate = value.UpdatedDate;
            if (roles != null)
            {
               user.Roles = roles;
               await _Schoolcontext.Users.AddAsync(user);
               await _Schoolcontext.SaveChangesAsync();
            }
            return user;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<User>Put(int id, [FromBody] UserDAO value)
        {
            var change = _Schoolcontext.Users.Find(id);
            if(change != null)
            {
                change.UserName = value.UserName;
                change.UserPassword = value.UserPassword;
                change.DateOfBirth = value.DateOfBirth;
                change.Gender = value.Gender;
                change.CurrentAddress = value.CurrentAddress;
                change.PermanentAddress = value.PermanentAddress;
                change.City = value.City;
                change.Nationality = value.Nationality;
                change.PinCode = value.PinCode;
                change.Email = value.Email;
                change.CreateDate = value.CreateDate;
                change.UpdatedDate = value.UpdatedDate;

                
            }
            await _Schoolcontext.SaveChangesAsync();
            return change;
        }

        [HttpPut("api/UserId")]
        public async Task<User> Put(int id, [FromBody] PassUp value)
        {
            var change = _Schoolcontext.Users.Find(id);
            if (change != null)
            {
                change.UserPassword = value.Password;
            }
            await _Schoolcontext.SaveChangesAsync();
            return change;
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var useby = _Schoolcontext.Users.FirstOrDefault(u => u.UserId == id);
            if (useby != null)
            {
                _Schoolcontext.Users.Remove(useby);
                await  _Schoolcontext.SaveChangesAsync();
            }
        }
    }
}
