namespace PlanetWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Contracts;
    using Models.MilitaryUnits;
    using Models.MilitaryUnits.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons;
    using Models.Weapons.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException(
                    string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                _ => throw new InvalidOperationException(
                    string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            const double TrainCosts = 1.25;

            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(TrainCosts);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planetFirst = this.planets.FindByName(planetOne);
            IPlanet planetSecond = this.planets.FindByName(planetTwo);
            IPlanet winner;
            IPlanet loser;

            if (planetFirst.MilitaryPower > planetSecond.MilitaryPower)
            {
                winner = planetFirst;
                loser = planetSecond;
                planetFirst.Spend(planetFirst.Budget / 2);
                planetFirst.Profit(planetSecond.Budget / 2);
                planetFirst.Profit(planetSecond.Army.Sum(a => a.Cost) + planetSecond.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(planetTwo);
            }
            else if (planetSecond.MilitaryPower > planetFirst.MilitaryPower)
            {
                winner = planetSecond;
                loser = planetFirst;
                planetSecond.Spend(planetSecond.Budget / 2);
                planetSecond.Profit(planetFirst.Budget / 2);
                planetSecond.Profit(planetFirst.Army.Sum(a => a.Cost) + planetFirst.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(planetOne);
            }
            else
            {
                if (planetFirst.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) && planetSecond.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    || planetFirst.Weapons.All(w => w.GetType().Name != nameof(NuclearWeapon)) && planetSecond.Weapons.All(w => w.GetType().Name != nameof(NuclearWeapon)))
                {
                    planetFirst.Spend(planetFirst.Budget / 2);
                    planetSecond.Spend(planetSecond.Budget / 2);

                    return OutputMessages.NoWinner;
                }

                if (planetFirst.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winner = planetFirst;
                    loser = planetSecond;
                    planetFirst.Spend(planetFirst.Budget / 2);
                    planetFirst.Profit(planetSecond.Budget / 2);
                    planetFirst.Profit(planetSecond.Army.Sum(a => a.Cost) + planetSecond.Weapons.Sum(w => w.Price));
                    this.planets.RemoveItem(planetTwo);
                }
                else
                {
                    winner = planetSecond;
                    loser = planetFirst;
                    planetSecond.Spend(planetSecond.Budget / 2);
                    planetSecond.Profit(planetFirst.Budget / 2);
                    planetSecond.Profit(planetFirst.Army.Sum(a => a.Cost) + planetFirst.Weapons.Sum(w => w.Price));
                    this.planets.RemoveItem(planetOne);
                }
            }

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}