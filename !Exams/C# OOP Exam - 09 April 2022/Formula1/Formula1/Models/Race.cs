using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOflaps;
        private readonly List<IPilot> pilots;
        public Race(string raceName, int numberOflaps)
        {
            this.raceName = raceName;
            this.numberOflaps = numberOflaps;
            TookPlace = false;
            this.pilots = new List<IPilot>();
        }
        public bool TookPlace { get;  set; }
        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get { return this.numberOflaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOflaps = value;
            }
        }
        public ICollection<IPilot> Pilots => this.pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
        => this.pilots.Add(pilot);
        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            if (TookPlace == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {this.pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOflaps}");
            sb.AppendLine($"Took place: {TookPlace}");
            return sb.ToString().Trim();
        }
    }
}
