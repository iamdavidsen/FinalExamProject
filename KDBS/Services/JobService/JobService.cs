using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using KDBS.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.JobService {
    public class JobService : IJobService {
        private readonly ApplicationDbContext _dbContext;

        public JobService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<JobModel>> GetJobs()
        {
            return _dbContext.Jobs.ToListAsync();
        }
        
        public Task<List<JobModel>> GetRecruiterJobs(string recruiterId)
        {
            return _dbContext.Jobs.Where(j => j.RecruiterId == recruiterId).ToListAsync();
        }

        public async Task<JobModel> GetJob(string jobId)
        {
            var job = await _dbContext.Jobs.Where(j => j.JobId == jobId).FirstOrDefaultAsync();

            if (job == null) throw new ObjectNotFoundException("The job does not exist");

            return job;
        }

        public async Task CreateJob(JobModel jobModel)
        {
            await _dbContext.Jobs.AddAsync(jobModel);
            await _dbContext.SaveChangesAsync();
        }

        public Task EditJob(JobModel jobModel)
        {
            _dbContext.Jobs.Update(jobModel);
            return _dbContext.SaveChangesAsync();
        }

        public async Task DeleteJob(string jobId)
        {
            var job = await GetJob(jobId);

            _dbContext.Jobs.Remove(job);
            await _dbContext.SaveChangesAsync();
        }
    }
}
