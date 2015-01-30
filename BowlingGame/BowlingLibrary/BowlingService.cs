using System;
using System.Linq;

namespace BowlingLibrary
{
    public class BowlingService : IBowlingService
    {
        public bool IsGameOver { get; private set; }
        private bool isStrikeBonus;
        private bool isSpareBonus;
        private int setNumber;
        public  int SetNumber { get { return setNumber + 1; } }
        private BowlingSet currentBowlingSet;
        public int Score { get; private set; }
        private BowlingSet[] bowlingSets;
        private int scoredSet;
        public BowlingService()
        {
            scoredSet = 0;
            Score = 0;
            setNumber = 0;
            IsGameOver = false;
            isStrikeBonus = false;
            isSpareBonus = false;
            currentBowlingSet = new BowlingSet();
            bowlingSets = new BowlingSet[10];
            bowlingSets[setNumber] = currentBowlingSet;
        }
        public int RollBall(int noOfPins)
        {
            currentBowlingSet.Roll(noOfPins);
            CalculateScore(noOfPins);
            if (setNumber < 9 &&( currentBowlingSet.Rolls.Count > 1 || currentBowlingSet.Rolls.Sum(roll => roll) == 10))
            {
                GoToNextSet();
            }
            return Score;
        }

        private void GoToNextSet()
        {
            currentBowlingSet.IsComplete = true;
            setNumber++;
            currentBowlingSet = new BowlingSet();
            bowlingSets[setNumber] = currentBowlingSet;
        }

        
        private void CalculateForSpare()
        {
            var setToBeCalculated = bowlingSets[scoredSet];
            if (scoredSet<9&&bowlingSets[scoredSet + 1] != null)
            {
                setToBeCalculated.Bonus = bowlingSets[scoredSet + 1].Rolls[0];
                Score += setToBeCalculated.Bonus;
                scoredSet++;
            }
            else if (setToBeCalculated.Rolls.Count > 2)
            {
                scoredSet++;
            }
        }

        private void CalculateForStrike()
        {
            var setToBeCalculated = bowlingSets[scoredSet];
            if(setToBeCalculated.Rolls.Count>2)
            {
                scoredSet++;
            }
            else if (scoredSet<10 && bowlingSets[scoredSet + 1] != null && bowlingSets[scoredSet + 1].Rolls.Count>1)
            {
                setToBeCalculated.Bonus = bowlingSets[scoredSet + 1].Rolls[0] + bowlingSets[scoredSet + 1].Rolls[1];
                Score += setToBeCalculated.Bonus;
                scoredSet++;
            }
            
            else if (scoredSet<9 && bowlingSets[scoredSet + 1] != null && bowlingSets[scoredSet + 2] != null)
            {
                setToBeCalculated.Bonus = bowlingSets[scoredSet + 1].Rolls[0] + bowlingSets[scoredSet + 2].Rolls[0];
                Score += setToBeCalculated.Bonus;
                scoredSet++;
            }
        }

        private void CalculateScore(int currentScore)
        {
            if(scoredSet<0)
                return;
            Score += currentScore;
            var setToBeCalculated = bowlingSets[scoredSet];
            if (setToBeCalculated.IsStrike)
            {
                CalculateForStrike();
            }
            else if (setToBeCalculated.IsSpare)
            {
                CalculateForSpare();
            }
            else if(currentBowlingSet.IsComplete)
            {
                scoredSet++;
            }
        }



        public int GetScore()
        {
            return Score;
        }
    }

}