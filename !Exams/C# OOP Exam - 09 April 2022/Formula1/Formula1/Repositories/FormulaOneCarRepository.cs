
namespace Formula1.Repositories
{
using System.Linq;
using Formula1.Models.Contracts;
using System.Collections.Generic;
using Formula1.Repositories.Contracts;
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
            => this.cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
            => this.cars.Add(model);

        public bool Remove(IFormulaOneCar model)
            => this.cars.Remove(model);

        public IFormulaOneCar FindByName(string name)
            => this.cars.FirstOrDefault(c => c.Model == name);
    }
}
