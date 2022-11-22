
namespace Formula1.Repositories
{
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();

        public void Add(IRace model)
        => this.races.Add(model);

        public IRace FindByName(string name)
         => this.races.FirstOrDefault(s => s.RaceName == name);

        public bool Remove(IRace model)
        => this.races.Remove(model);
    }
}
