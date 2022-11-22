
namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;

    using System.Collections.Generic;
    using System.Linq;
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
            => this.units.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
            => this.units.Add(model);

        public IMilitaryUnit FindByName(string name)
            => this.units.FirstOrDefault(u => u.GetType().Name == name);

        public bool RemoveItem(string name)
            => this.units.Remove(this.FindByName(name));
    }
}
