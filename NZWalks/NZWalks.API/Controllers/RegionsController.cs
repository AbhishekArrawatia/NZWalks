using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTO;
using NZWalks.API.Models;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions () {
            
            var regions = await _regionRepository.GetAllRegions();
            //var regionsDto = new List<RegionsDTO>();
            var regionsDto =  mapper.Map<List<RegionsDTO>>(regions);
            //foreach (var region in regions)
            //{
            //    var regionDto = new RegionsDTO()
            //    {
            //        Id = region.Id,
            //        Area = region.Area,
            //        Name = region.Name,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Code = region.Code,
            //        Population = region.Population
            //    };
            //    regionsDto.Add(regionDto);
            //}
            
            return Ok(regionsDto);
        }
    }
}
