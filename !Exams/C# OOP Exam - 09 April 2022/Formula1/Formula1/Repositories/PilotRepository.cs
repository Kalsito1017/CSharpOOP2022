
namespace Formula1.Repositories
{
using System.Linq;
using Formula1.Models.Contracts;
using System.Collections.Generic;
using Formula1.Repositories.Contracts;
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;
        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();

        public void Add(IPilot model)
        => this.pilots.Add(model);

        public IPilot FindByName(string name)
         => this.pilots.FirstOrDefault(s => s.FullName == name);

        public bool Remove(IPilot model)
        => this.pilots.Remove(model);
    }
}
