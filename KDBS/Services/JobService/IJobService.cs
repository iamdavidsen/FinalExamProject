using System.Collections.Generic;
using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.JobService
{
    public interface IJobService {
        Task<List<JobModel>> GetJobs();
        
        Task<List<JobModel>> GetJobs(string? searchQuery, int? salary, List<string>? categories, List<string>? goods);
        
        Task<List<JobModel>> GetCompanyJobs(string companyId);

        Task<JobModel> GetJob(string jobId);

        Task CreateJob(JobModel jobModel);

        Task EditJob(JobModel jobModel);

        Task DeleteJob(string jobId);
    }

}
