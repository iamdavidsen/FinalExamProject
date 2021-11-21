using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KDBS.Data;
using Microsoft.EntityFrameworkCore;

namespace KDBS.Services.GoodsService
{
    internal class GoodsService : IGoodsService
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GoodsModel>> GetGoods()
        {
            return _dbContext.Goods.ToListAsync();
        }

        public Task<List<GoodsModel>> GetGoods(List<string> goodsIds)
        {
            return _dbContext.Goods.Where(g => goodsIds.Contains(g.GoodsId)).ToListAsync();
        }

        public Task<GoodsModel> GetGoods(string goodsId)
        {
            return _dbContext.Goods.Where(g => g.GoodsId == goodsId).FirstOrDefaultAsync();
        }

        public async Task CreateGoods(GoodsModel goodsModel)
        {
            await _dbContext.Goods.AddAsync(goodsModel);
            await _dbContext.SaveChangesAsync();
        }

        public Task EditGoods(GoodsModel goodsModel)
        {
            _dbContext.Goods.Update(goodsModel);
            return _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGoods(string goodsId)
        {
            var goods = await GetGoods(goodsId);

            _dbContext.Goods.Remove(goods);
            await _dbContext.SaveChangesAsync();
        }
    }
}
