using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FirstAPI.Data;
using FirstAPI.Models.Domain;
using FirstAPI.Models.Domain.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private NZwalkdbcontext dbContext;

        public RegionsController(NZwalkdbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            var regionDto = new List<RegionDto>();
            foreach(var region in regions )
            {
                regionDto.Add( new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl

                });
            }

            return Ok(regionDto);
        }
 
        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] Guid Id)
        {
            var region = dbContext.Regions.Find(Id);
            {
                if (region == null){
                    return NotFound();
                }
                var regionDto = new RegionDto
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl

                };
                return Ok(regionDto);
            }
        }


    [HttpPost]
    public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        var regionDomainmodel = new Regions
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl,
        };
    dbContext.Regions.Add(regionDomainmodel);
    dbContext.SaveChanges();

    var regionDto = new RegionDto
    {
            Id = regionDomainmodel.Id,
            Code = regionDomainmodel.Code,
            Name = regionDomainmodel.Name,
            RegionImageUrl = regionDomainmodel.RegionImageUrl,
    };

    return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

    }

    [HttpDelete]
    [Route("{Id:Guid}")]
    public IActionResult Delete([FromRoute] Guid Id)
    {
        var region = dbContext.Regions.Find(Id);
        if (Id == null)
        {
         return NotFound();
        } 
        dbContext.Regions.Remove(region);
        dbContext.SaveChanges();
        return Ok();
    }
    
    }
}