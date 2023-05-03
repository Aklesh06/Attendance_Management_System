using AtendanceMnagement.Context;
using AtendanceMnagement.DAO;
using AtendanceMnagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtendanceMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private Schoolcontext role;
        public RolesController(Schoolcontext role)
        {
            this.role = role;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<Roles>> Get()
        {
            return role.Roles;
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<Roles> Post([FromBody] Roles value)
        {
            Roles roles = new Roles();
            await role.Roles.AddAsync(value);
            await role.SaveChangesAsync();
            return roles;
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Roles value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var roles = role.Roles.FirstOrDefault(r => r.RolesId == id);
            if (roles != null)
            {
                role.Roles.Remove(roles);
                await role.SaveChangesAsync();
            }
         
        }
    }
}
