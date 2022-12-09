using Easter.Core.Contracts;
using Easter.Models;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private const int MinBunnyEnergyForColoring = 50;
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;
        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);
             
            return string.Format(OutputMessages.EggAdded, eggName);

        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunniesforColoring = this.bunnies.Models.
                Where(b => b.Energy >= MinBunnyEnergyForColoring
                && b.Dyes.Count(d => !d.IsFinished()) > 0)
                .OrderByDescending(b => b.Energy)
                .ToList();
            if (bunniesforColoring.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            IEgg egg = this.eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();
            foreach (IBunny bunny in bunniesforColoring)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);

                }
                if (egg.IsDone())
                {
                    break;
                }
            }
            return string.Format(egg.IsDone()
               ? OutputMessages.EggIsDone
               : OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.eggs.Models.Count(e => e.IsDone())} eggs are done!")
                .AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
