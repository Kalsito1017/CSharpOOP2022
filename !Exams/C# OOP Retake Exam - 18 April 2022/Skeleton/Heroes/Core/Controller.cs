using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;
        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            IHero hero;
            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
            }
            else
            {
                hero = new Barbarian(name, health, armour);
            }
            this.heroes.Add(hero);
            return $"Successfully added {(type == nameof(Knight) ? "Sir" : "Barbarian")} {name} to the collection.";
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.Models.Any(s => s.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            if (type != nameof(Mace) && type != nameof(Claymore))
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            IWeapon weapon;
            if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                weapon = new Claymore(name, durability);
            }
            this.weapons.Add(weapon);
            return $"A {weapon.GetType().Name.ToLower()} {weapon.Name} is added to the collection.";

        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.Models.FirstOrDefault(w => w.Name == heroName);
            IWeapon weapon = this.weapons.Models.FirstOrDefault(H => H.Name == weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }
        public string StartBattle()
        {
            IMap map = new Map();
            ICollection<IHero> players = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(players);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in this.heroes.Models.OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name))
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
