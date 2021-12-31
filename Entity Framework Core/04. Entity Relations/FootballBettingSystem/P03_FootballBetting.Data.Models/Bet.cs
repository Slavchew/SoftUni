using System;
using P03_FootballBetting.Data.Models.Enumerations;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
