using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using KDBS.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.CompanyService {
    class CompanyService : ICompanyService {
        private readonly ApplicationDbContext _dbContext;

        public CompanyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<CompanyModel> GetCompany(string companyId)
        {
            var company = await _dbContext.Companies.Where(r => r.CompanyId == companyId).FirstOrDefaultAsync();

            if (companyId == null) throw new ObjectNotFoundException("The company does not exist");

            return company;
        }
        
        public async Task<CompanyModel> GetCompanyByUser(string userId)
        {
            var company = await _dbContext.Companies.Where(r => r.UserId == userId).FirstOrDefaultAsync();

            if (company == null) throw new ObjectNotFoundException($@"A company with the user id {userId} was not found");

            return company;
        }
        
        public async Task CreateCompany(CompanyModel companyModel)
        {
            await _dbContext.Companies.AddAsync(companyModel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
