using System;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    class Stats
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;
        private const double StatsCount = 5;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.ValidateStat(nameof(Endurance), value);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                this.ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                this.ValidateStat(nameof(Passing), value);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                this.ValidateStat(nameof(Shooting), value);
                this.shooting = value;
            }
        }

        public double AverageStat => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / StatsCount;

        private void ValidateStat(string name,int value)
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExcMsg, name, MinStat, MaxStat));
            }
        }

    }
}
