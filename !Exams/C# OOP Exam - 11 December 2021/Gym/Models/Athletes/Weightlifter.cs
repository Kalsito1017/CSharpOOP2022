namespace Gym.Models.Athletes
{
    using System;
    using Utilities.Messages;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;
        private const int StaminaIncreasement = 10;
        private const int StaminaMax = 100;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            Stamina += StaminaIncreasement;

            if (Stamina >= StaminaMax)
            {
                Stamina = StaminaMax;

                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}