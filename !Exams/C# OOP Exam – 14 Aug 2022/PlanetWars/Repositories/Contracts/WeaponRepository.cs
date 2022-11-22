namespace PlanetWars.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => this.weapons.AsReadOnly();
        public void AddItem(IWeapon model)
            => this.weapons.Add(model);

        public IWeapon FindByName(string name)
            => this.weapons.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
            => this.weapons.Remove(this.FindByName(name));
    }
}