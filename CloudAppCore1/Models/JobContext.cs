using Microsoft.EntityFrameworkCore;

namespace CloudAppCore1.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        { }

        public DbSet<Job> Jobs { get; set; }
    }

    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
    }
}
