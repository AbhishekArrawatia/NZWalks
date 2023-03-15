using NZWalks.API.DTO;
using NZWalks.API.Models;
using AutoMapper;
namespace NZWalks.API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionsDTO>();
        }
    }
}
