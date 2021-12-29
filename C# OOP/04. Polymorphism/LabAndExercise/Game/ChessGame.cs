using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class ChessGame : TwoPlayerGame
    {
        private bool isWhitePlaying;

        public ChessGame(Player playerOne, Player playerTwo) 
            : base(playerOne, playerTwo)
        {
        }

        public override void Start()
        {
            StartDate = DateTime.Now;
        }

        public override void Stop()
        {
            EndDate = DateTime.Now;
        }

        public Player GetMovingPlayer()
        {
            if (isWhitePlaying)
            {
                return playerOne;
            }
            else
            {
                return playerTwo;
            }

        }

        public string PrintIfArmageddon()
        {
            return $"Armagedon sux";
        }

        public override string GetDiscription()
        {
            return $"{playerOne} is playing {playerTwo} and they are thinking hard";
        }
    }
}
