using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class TennisGame : TwoPlayerGame
    {
        public TennisGame(Player playerOne, Player playerTwo) 
            : base(playerOne, playerTwo)
        {
        }

        public override string GetDiscription()
        {
            return $"{playerOne} broke his racket {playerTwo} hit the judje";
        }

        public string IsGrandSlam() 
        {
            return $"GrandSlam is the best";
        }
    }
}
