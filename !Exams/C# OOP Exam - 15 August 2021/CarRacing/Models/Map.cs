using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
namespace CarRacing.Models
{
    public  class Map : IMap
    {
        private const double strictMultiplayer = 1.2;
        private const double aggresiveMultiplayer = 1.1;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            racerOne.Race();
            racerTwo.Race();
            double chanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience *
            (racerOne.RacingBehavior == "strict" ? strictMultiplayer : aggresiveMultiplayer);
            double secondcarChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience *
            (racerTwo.RacingBehavior == "strict" ? strictMultiplayer : aggresiveMultiplayer);
            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                (chanceOfWinning > secondcarChanceOfWinning ? racerOne.Username : racerTwo.Username));
        }
    }
}
