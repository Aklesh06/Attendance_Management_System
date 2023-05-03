using AtendanceMnagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AtendanceMnagement.Context
{
    public class Schoolcontext : DbContext
    {
        public Schoolcontext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        internal Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
