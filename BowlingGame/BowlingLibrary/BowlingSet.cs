
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingLibrary
{
    public class BowlingSet
    {
        public List<int> Rolls { get; set; } 
        public bool IsComplete { get; set; }
        public bool IsSpare { get; set; }
        public bool IsStrike { get; set; }
        public int Score
        {
            get { return Rolls.Sum(r => r); }
        }
        public int TotalScore{get { return Score + Bonus; }}
        public int Bonus { get; set; }
        public BowlingSet()
        {
            Rolls = new List<int>();
        }

        public void Roll(int noOfPins)
        {
            if (!IsComplete)
            {
                Rolls.Add(noOfPins);
                if (Score != 10) return;
                if (Rolls.Count == 1)
                    IsStrike = true;
                else
                {
                    IsSpare = true;
                }
            }
            else
            {
                throw new Exception("Set is complete, cannot throw anymore");
            }
        }
    }
}
