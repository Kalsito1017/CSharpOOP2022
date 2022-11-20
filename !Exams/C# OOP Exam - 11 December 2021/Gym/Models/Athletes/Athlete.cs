namespace Gym.Models.Athletes
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public string FullName
        {
            get => this.fullName;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                this.motivation = value;
            }
        }
        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}