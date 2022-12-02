namespace Heroes.Repositories
{
using System.Linq;
using Heroes.Models.Contracts;
using System.Collections.Generic;
using Heroes.Repositories.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void Add(IWeapon model)
        => this.weapons.Add(model);

        public IWeapon FindByName(string name)
        => this.weapons.FirstOrDefault( s=> s.Name == name);

        public bool Remove(IWeapon model)
        => this.weapons.Remove(model);
    }
}
