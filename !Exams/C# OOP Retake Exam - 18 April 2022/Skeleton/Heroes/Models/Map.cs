using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {          
                List<Knight> knights = new List<Knight>();
                List<Barbarian> barbarians = new List<Barbarian>();
            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == nameof(Knight))
                {
                    knights.Add((Knight)hero);
                }
                else
                {
                    barbarians.Add((Barbarian)hero);
                }
            }
            while (knights.Count(j => j.IsAlive) > 0 && barbarians.Count(s => s.IsAlive) > 0)
            {
                foreach (var knight in knights.Where(k => k.IsAlive && k.Weapon.Durability > 0))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive && b.Weapon.Durability > 0))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive && b.Weapon.Durability > 0))
                    {
                       foreach (var knight in knights.Where(k => k.IsAlive && k.Weapon.Durability > 0))
                        {
                             knight.TakeDamage(barbarian.Weapon.DoDamage());
                         }
                         
                    }             
            }
            return knights.Count(k => k.IsAlive) == 0
                ? $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle."
                : $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle.";

        }
    }
}
