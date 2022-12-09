using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly List<IDye> dyes;
        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.dyes = new List<IDye>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
             protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                this.energy = value;
            }

        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
         => this.Dyes.Add(dye);

        public abstract void Work();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Name: {Name}")
                .AppendLine($"Energy: {Energy}")
                .AppendLine($"Dyes: {Dyes.Count(d => !d.IsFinished())} not finished");

            return sb.ToString().TrimEnd();
        }
    }
}
