using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private Schoolcontext _Schoolcontext;
        public TopicController(Schoolcontext Schoolcontext)
        {
            this._Schoolcontext = Schoolcontext;
        }

            // GET: api/<TopicController>
        [HttpGet]
        public async Task<IEnumerable<Topic>> Get()
        {
            return _Schoolcontext.Topics;
        }

        // GET api/<TopicController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TopicController>
        [HttpPost]
        public async Task<Topic> Post([FromBody] TopicDAO value)
        {
            Topic topic = new Topic();
            var teacher= _Schoolcontext.Teachers.Where(x=>x.TeacherId==value.TeacherId).FirstOrDefault();

            if (teacher != null)
            {
                topic.Teachers = teacher;
                topic.TopicId= value.TopicId;
                topic.Notes = value.Notes;
                await _Schoolcontext.Topics.AddAsync(topic);
                await _Schoolcontext.SaveChangesAsync();
            }
            return topic;
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public async Task<Topic> Put(int id, [FromBody] TopicDAO value)
        {
            Topic topic=new Topic();
            var changetopic = _Schoolcontext.Topics.Where(x=>x.TeacherId==value.TeacherId).FirstOrDefault();
            if(changetopic != null)
            {
                topic.Notes = value.Notes;
                topic.Date = value.Date;
                topic.CreatedDate = value.CreatedDate;
                topic.UpdatedDate = value.UpdatedDate;

                await _Schoolcontext.Topics.AddAsync(topic);
                await _Schoolcontext.SaveChangesAsync();
            }
            return topic;
        }

        // DELETE api/<TopicController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var note = _Schoolcontext.Topics.FirstOrDefault(tp => tp.TopicId == id);
            if(note != null)
            {
                _Schoolcontext.Topics.Remove(note);
                await _Schoolcontext.SaveChangesAsync();
            }
        }
    }
}
