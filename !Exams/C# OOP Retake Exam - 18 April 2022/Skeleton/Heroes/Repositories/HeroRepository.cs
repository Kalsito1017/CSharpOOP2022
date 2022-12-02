namespace Heroes.Repositories
{
using System.Linq;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using Heroes.Models.Contracts;
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;
        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)
         => this.heroes.Add(model);

        public IHero FindByName(string name)
        => this.heroes.FirstOrDefault(s => s.Name == name);

        public bool Remove(IHero model)
        => this.heroes.Remove(model);
    }
}
