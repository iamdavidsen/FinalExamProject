using System.Collections.Generic;
using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.GoodsService
{
    public interface IGoodsService {
        Task<List<GoodsModel>> GetGoods();
        
        Task<GoodsModel> GetGoods(string goodsId);

        Task CreateGoods(GoodsModel jobModel);

        Task EditGoods(GoodsModel jobModel);

        Task DeleteGoods(string jobId);
    }

}
