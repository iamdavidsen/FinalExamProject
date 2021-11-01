using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<CompanyModel> GetCompany(string companyId);
        
        Task<CompanyModel> GetCompanyByUser(string userId);

        Task CreateCompany(CompanyModel companyModel);
    }

}
