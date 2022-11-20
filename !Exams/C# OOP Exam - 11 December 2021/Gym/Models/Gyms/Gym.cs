namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Athletes.Contracts;
    using Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; }
        public double EquipmentWeight
            => Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment
            => this.equipment.AsReadOnly();
        public ICollection<IAthlete> Athletes
            => this.athletes.AsReadOnly();
        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity > Athletes.Count)
            {
                this.athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public bool RemoveAthlete(IAthlete athlete)
            => this.athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
            => this.equipment.Add(equipment);

        public void Exercise()
            => this.athletes.ForEach(a => a.Exercise());

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {(Athletes.Count == 0 ? "No athletes" : string.Join(", ", this.athletes.Select(a => a.FullName)))}")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}