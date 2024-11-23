using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models.Domain.Dto
{
    public class AddRegionRequestDto
    {
        public String Code {get; set;}
        public string Name {get; set;}
        public string? RegionImageUrl {get; set;}
    }
}