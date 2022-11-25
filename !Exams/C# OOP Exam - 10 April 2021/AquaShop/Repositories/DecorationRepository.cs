﻿using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();
        public void Add(IDecoration model)
         => this.decorations.Add(model);
        public IDecoration FindByType(string type)
        => this.decorations.FirstOrDefault(s => s.GetType().Name == type);
        public bool Remove(IDecoration model)
        => this.decorations.Remove(model);
    }
}
