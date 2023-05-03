using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private Schoolcontext Schoolcontext;
        public TeacherController(Schoolcontext Schoolcontext)
        {
            this.Schoolcontext = Schoolcontext;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public async Task<IEnumerable<Teacher>> Get()
        {
            return Schoolcontext.Teachers;
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost]
        public async Task<Teacher> Post([FromBody] TeachersDAO value)
        {
            Teacher teacher = new Teacher();
            var user = Schoolcontext.Users.Where(x=>x.UserId== value.UserId).FirstOrDefault();
            var subject = Schoolcontext.Subjects.Where(x=>x.SubjectId==value.SubjectId).FirstOrDefault();

            if(user!=null && subject != null)
            {
                teacher.User = user;
                teacher.Subject = subject;
                teacher.TeacherId = value.TeacherId;
                teacher.CreatedDate = DateTime.Now;
                teacher.UpdatedDate = DateTime.Now;

                await Schoolcontext.Teachers.AddAsync(teacher);
                await Schoolcontext.SaveChangesAsync();

            }
            return teacher;
           
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var admin = Schoolcontext.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (admin != null)
            {
                Schoolcontext.Teachers.Remove(admin);
                await Schoolcontext.SaveChangesAsync();
            }
           // return admin;
        }
    }
}
