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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegion")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            var region = await _regionRepository.GetRegionAsync(id);
            
            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionsDTO>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(AddRegionRequest addRegionRequest)
        {
            var region = new Region
            {
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area
            };

            region = await _regionRepository.AddRegionAsync(region);

            var regionDTO = mapper.Map<RegionsDTO>(region);

            return CreatedAtAction(nameof(GetRegion), new { id = regionDTO.Id },regionDTO );

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion (Guid id)
        {
            var region = await _regionRepository.DeleteRegionAsync(id);
            if(region == null) { return NotFound();}
            var regionDTO = mapper.Map<RegionsDTO>(region);
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var region = new Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Area = updateRegionRequest.Area
            };

            region = await _regionRepository.UpdateRegionAsync(id, region);

            if(region == null) { return NotFound();}

            var regionDTO = mapper.Map<RegionsDTO>(region);

            return Ok(regionDTO);
        }
    }
}
