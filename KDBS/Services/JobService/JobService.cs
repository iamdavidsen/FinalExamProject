using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using KDBS.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.JobService
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _dbContext;

        public JobService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<JobModel>> GetJobs()
        {
            return _dbContext.Jobs
                .Include(j => j.Company)
                .ToListAsync();
        }
        
        public async Task<List<JobModel>> GetJobs(string? searchQuery, int? salary, List<string>? categories, List<string>? goods)
        {
            if (string.IsNullOrEmpty(searchQuery)) searchQuery = null;
            if (salary == 0) salary = null;
            if (categories?.Count == 0) categories = null;
            if (goods?.Count == 0) goods = null;
            
            return (await _dbContext.Jobs
                .Where(j => searchQuery == null || j.Title.Contains(searchQuery))
                .Where(j => salary == null || j.Salary > salary)
                .Where(j => categories == null || categories.Contains(j.CategoryId))
                .Include(j => j.Company)
                .Include(j => j.Goods)
                .ToListAsync())
                .Where(j => goods == null || goods.All(id => j.Goods != null && j.Goods.Any(g => g.GoodsId == id)))
                .ToList();
        }

        public Task<List<JobModel>> GetCompanyJobs(string companyId)
        {
            return _dbContext.Jobs.Where(j => j.CompanyId == companyId).ToListAsync();
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
