namespace Gym.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Athletes;
    using Models.Athletes.Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;
    using Models.Gyms;
    using Models.Gyms.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidGymType)
            };

            this.gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType)
            };

            this.equipment.Add(currentEquipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.First(q => q.Name == gymName);
            IEquipment currentEquipment = this.equipment.FindByType(equipmentType);

            if (currentEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(currentEquipment);
            this.equipment.Remove(currentEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.First(q => q.Name == gymName);

            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType)
            };

            if (gym.GetType().Name == nameof(BoxingGym) && athlete is Boxer
                || gym.GetType().Name == nameof(WeightliftingGym) && athlete is Weightlifter)
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(q => q.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(q => q.Name == gymName);

            double weight = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}