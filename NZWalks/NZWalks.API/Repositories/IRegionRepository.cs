using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllRegions();
       Task<Region> GetRegionAsync(Guid id);
       Task<Region> AddRegionAsync(Region region);
       Task<Region> DeleteRegionAsync(Guid id);
       Task<Region> UpdateRegionAsync(Guid id, Region region);
    }
}
