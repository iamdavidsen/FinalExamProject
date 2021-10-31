using System.Collections.Generic;
using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.RecruiterService
{
    public interface IRecruiterService
    {
        Task<RecruiterModel> GetRecruiter(string recruiterId);
        
        Task<RecruiterModel> GetRecruiterByUser(string userId);

        Task CreateRecruiter(RecruiterModel recruiterModel);
    }

}
