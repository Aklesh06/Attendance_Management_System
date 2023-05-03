using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private Schoolcontext subject;
        public SubjectController(Schoolcontext subject)
        {
            this.subject = subject;
        }
    
        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IEnumerable<Subject>> Get()
        {
            return subject.Subjects;
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task<Subject> Post([FromBody] Subject value)
        {
            Subject subjects = new Subject();
            await subject.Subjects.AddAsync(value);
            await subject.SaveChangesAsync();
            return subjects;
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Subject value)
        {
            var changesubject = subject.Subjects.Find(id);
            if(changesubject != null)
            {
                changesubject.SubjectName = value.SubjectName;
                changesubject.CreatedDate = value.CreatedDate;
                changesubject.UpdatedDate = value.UpdatedDate;

                subject.SaveChanges();
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var sub = subject.Subjects.FirstOrDefault(st => st.SubjectId == id);
            if(sub != null)
            {
                subject.Subjects.Remove(sub);
                await subject.SaveChangesAsync();
            }
        }
    }
}
