﻿namespace spacetraders.Models
{
    public class Faction
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string headquarters { get; set; }
        public List<FactionTrait> traits { get; set; }
    }
}