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
    }
}
