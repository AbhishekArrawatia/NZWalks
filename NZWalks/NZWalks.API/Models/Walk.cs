﻿namespace NZWalks.API.Models
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //Navigation Properties

        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
