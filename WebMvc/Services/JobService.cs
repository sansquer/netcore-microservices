using HttpLib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Config;
using WebMvc.ViewModels;

namespace WebMvc.Services
{
    public class JobService : IJobService
    {
        private readonly IHttpClient _apiClient;
        private readonly ApiConfig _apiConfig;

        public JobService(IHttpClient httpClient, ApiConfig apiConfig)
        {
            _apiClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var dataString = await _apiClient.GetStringAsync(_apiConfig.JobsApiUrl + "/api/jobs");
            return JsonConvert.DeserializeObject<IEnumerable<Job>>(dataString);
        }

        public async Task<Job> GetJob(int jobId)
        {
            var dataString = await _apiClient.GetStringAsync(_apiConfig.JobsApiUrl + "/api/jobs/" + jobId);
            return JsonConvert.DeserializeObject<Job>(dataString);
        }

        public async Task<Job> AddJob(string title, string company, string description, int salary)
        {
            Job newJob = new Job
            {
                Title = title,
                Company = company,
                Description = description,
                Salary = salary
            };
            var httpResponse = await _apiClient.PostAsync<Job>(_apiConfig.JobsApiUrl + "/api/jobs", newJob);
            return JsonConvert.DeserializeObject<Job>(httpResponse.Content.ToString());
        }

        //public async Task AddApplicant(JobApplicant jobApplicant)
        //{
        //    var response = await _apiClient.PostAsync(_apiConfig.JobsApiUrl + "/api/jobs/applicants", jobApplicant);
        //    response.EnsureSuccessStatusCode();
        //}
    }
}
