using System.Collections.Generic;
using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.JobService
{
    public interface IJobService {
        Task<List<JobModel>> GetJobs();
        
        Task<List<JobModel>> GetRecruiterJobs(string recruiterId);

        Task<JobModel> GetJob(string jobId);

        Task CreateJob(JobModel jobModel);

        Task EditJob(JobModel jobModel);

        Task DeleteJob(string jobId);
    }

}
