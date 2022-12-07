using NavalVessels.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private readonly List<string> targets;
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.ArmorThickness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
             set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                this.captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets.AsReadOnly();

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            target.ArmorThickness -= MainWeaponCaliber;
            if (ArmorThickness < 0)
            {
                ArmorThickness = 0;
            }
            this.targets.Add(target.Name);
            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
               .AppendLine($"- {this.Name}")
               .AppendLine($" *Type: {this.GetType().Name}")
               .AppendLine($" *Armor thickness: {ArmorThickness}")
               .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
               .AppendLine($" *Speed: {Speed} knots")
               .AppendLine($" *Targets: {(Targets.Count == 0 ? "None" : string.Join(", ", Targets))}");

            return sb.ToString().TrimEnd();
        }
    }
}
