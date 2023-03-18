using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            _context = nZWalksDbContext;
        }

        

        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionAsync(Guid id)
        {
           return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = new Guid();
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var region = await GetRegionAsync(id);
            if (region != null)
            {
                _context.Regions.Remove(region);
            }
            await _context.SaveChangesAsync();
            return region;

        }

        public async Task<Region> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion == null) { return null; }
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            existingRegion.Area = region.Area;
            await _context.SaveChangesAsync();
            return existingRegion;

        }

    }
}
