using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AquaShop.Models
{
    public class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            fishes = new List<IFish>();
            decorations = new List<IDecoration>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(s => s.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
         => this.Fish.Add(fish);

        public void Feed()
        => this.fishes.ForEach(f => f.Eat());

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{Name} ({this.GetType().Name}):")
                .AppendLine(
                    $"Fish: {(Fish.Count == 0 ? "none" : string.Join(", ", this.fishes.Select(f => f.Name).ToArray()))}")
                .AppendLine($"Decorations: {Decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
        public bool RemoveFish(IFish fish)
         => this.Fish.Remove(fish);
    }
}
