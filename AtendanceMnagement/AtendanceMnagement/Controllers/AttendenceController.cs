using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private Schoolcontext _Schoolcontext;
        public AttendenceController(Schoolcontext Schoolcontext)
        {
            this._Schoolcontext = Schoolcontext;
        }
        // GET: api/<AttendenceController>
        [HttpGet]
        public async Task<IEnumerable<Attendence>> Get()
        {
            return _Schoolcontext.Attendences;
        }

        // GET api/<AttendenceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttendenceController>
        [HttpPost]
        public async Task<Attendence> Post([FromBody] AttendenceDAO value)
        {
            Attendence attendence = new Attendence();
            var user = _Schoolcontext.Users.Where(x => x.UserId == value.UserId).FirstOrDefault();
            var subject = _Schoolcontext.Subjects.Where(x => x.SubjectId == value.SubjectId).FirstOrDefault();
            if (user != null && subject != null)
            {
                attendence.User = user;
                attendence.Subject = subject;
                attendence.AttendenceId = value.AttendenceId;
                attendence.IsPresent = value.IsPresent;
                attendence.AttendenceDate = DateTime.Today;
                attendence.CreatedBy = value.CreatedBy;
                attendence.CreatedDate = DateTime.Today;
                attendence.UpdatedDate = DateTime.Today;

                await _Schoolcontext.Attendences.AddAsync(attendence);
                await _Schoolcontext.SaveChangesAsync();
            }
            return attendence;

        }
        [HttpPost("AttandanceDetails")]
        public async Task<IEnumerable<StudentAttResponse>> GetStudentAttancdance([FromBody] StudentAtt value)
        {
            List<StudentAttResponse> attendence = new List<StudentAttResponse>();


            var studentAt = await _Schoolcontext.Attendences.Where(x => (x.UserId == value.UserID && x.AttendenceDate == value.AttandanceDate)).ToListAsync();
            if (studentAt != null)
            {
                foreach (var student in studentAt)
                {
                    StudentAttResponse data = new StudentAttResponse();
                    var subjectName = await _Schoolcontext.Subjects.Where(x => x.SubjectId == student.SubjectId).FirstOrDefaultAsync();
                    data.subject = subjectName.SubjectName;
                    data.Attandance = student.IsPresent == true ? "Present" : "Absent";
                    attendence.Add(data);
                }
            }
            return attendence;

        }


        // PUT api/<AttendenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Attendence value)
        {
        }

        // DELETE api/<AttendenceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var amanage = _Schoolcontext.Attendences.FirstOrDefault(a => a.AttendenceId == id);
            if (amanage != null)
            {
                _Schoolcontext.Attendences.Remove(amanage);
                await _Schoolcontext.SaveChangesAsync();
            }

        }
    }
}
