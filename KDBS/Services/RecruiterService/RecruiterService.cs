using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using KDBS.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.RecruiterService {
    class RecruiterService : IRecruiterService {
        private readonly ApplicationDbContext _dbContext;

        public RecruiterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<RecruiterModel> GetRecruiter(string recruiterId)
        {
            var recruiter = await _dbContext.Recruiters.Where(r => r.RecruiterId == recruiterId).FirstOrDefaultAsync();

            if (recruiterId == null) throw new ObjectNotFoundException("The recruiter does not exist");

            return recruiter;
        }
        
        public async Task<RecruiterModel> GetRecruiterByUser(string userId)
        {
            var recruiter = await _dbContext.Recruiters.Where(r => r.UserId == userId).FirstOrDefaultAsync();

            if (recruiter == null) throw new ObjectNotFoundException($@"A recruiter with the user id {userId} was not found");

            return recruiter;
        }
        
        public async Task CreateRecruiter(RecruiterModel recruiterModel)
        {
            await _dbContext.Recruiters.AddAsync(recruiterModel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
