using System.Threading.Tasks;
using KDBS.Models;

namespace KDBS.Services.GeocodingService
{
    public interface IGeocodingService
    {
        Task<Coordinate> GetCoordinate(string address, int zipcode);
    }

}
