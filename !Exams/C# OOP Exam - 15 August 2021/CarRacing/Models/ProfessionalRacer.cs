using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InitialRacingBehavior = "strict";
        private const int DrivingExperienceIncreasement = 10;
        public ProfessionalRacer(string username,ICar car)
            : base(username,InitialRacingBehavior,DrivingExperienceIncreasement, car)
        {
        }
        public override void Race()
        {
            base.Race();
            DrivingExperience += DrivingExperienceIncreasement;
        }
    }
}
