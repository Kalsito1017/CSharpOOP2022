namespace Gym.Models.Athletes
{
    using System;
    using Utilities.Messages;

    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        private const int StaminaIncreasement = 15;
        private const int StaminaMax = 100;

        public Boxer(string fullName, string motivation, int numberOfMedals)
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