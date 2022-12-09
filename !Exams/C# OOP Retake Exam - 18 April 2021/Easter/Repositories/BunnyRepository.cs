using Easter.Models;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;
        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => this.bunnies.AsReadOnly();

        public void Add(IBunny model)
        => this.bunnies.Add(model);

        public IBunny FindByName(string name)
        => this.bunnies.FirstOrDefault(s => s.Name == name);

        public bool Remove(IBunny model)
        => this.bunnies.Remove(model);
    }
}
