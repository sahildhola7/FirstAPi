using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstAPI.Models.Domain
{
    public class Walks
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string LengthInKm {get; set;}
        public string? WalkImageUrl {get; set;}
        public Guid DifficultyId {get; set;}
        public Guid RegionId {get; set;}
        public Difficulty Difficulty {get; set;}
        public Regions Regions {get; set;}
    }
}