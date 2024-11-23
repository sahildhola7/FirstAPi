using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models.Domain
{
    public class Regions
    {
        public Guid Id {get; set;}
        public String Code {get; set;}
        public string Name {get; set;}
        public string? RegionImageUrl {get; set;}
    }
}