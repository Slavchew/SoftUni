using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class TwoPlayerGame : Game
    {
        protected Player playerOne;
        protected Player playerTwo;

        public TwoPlayerGame(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }
    }
}
