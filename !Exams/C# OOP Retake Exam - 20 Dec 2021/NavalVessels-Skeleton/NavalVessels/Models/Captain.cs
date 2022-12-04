using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            this.fullName = fullName;
            this.vessels = new List<IVessel>();
            CombatExperience = 0;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                 throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                this.fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => this.vessels.AsReadOnly();

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            foreach (IVessel vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
