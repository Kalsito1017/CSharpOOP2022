using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;

amespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
{
    private readonly List<IEquipment> equipments;

    public EquipmentRepository()
    {
        this.equipments = new List<IEquipment>();
    }
    public IReadOnlyCollection<IEquipment> Models
        => this.equipments.AsReadOnly();
    public void Add(IEquipment model)
        => this.equipments.Add(model);

    public bool Remove(IEquipment model)
        => this.equipments.Remove(model);

    public IEquipment FindByType(string type)
        => this.equipments.FirstOrDefault(e => e.GetType().Name == type);
}
}