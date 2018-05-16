using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.ViewModels;

namespace WebMvc.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJob(int jobId);
        Task<Job> AddJob(string title, string company, string description, int salary);
        //Task AddApplicant(JobApplicant jobApplicant);
    }
}
