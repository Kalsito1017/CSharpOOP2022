namespace AquaShop.Models
{
using AquaShop.Models.Decorations.Contracts;
    public abstract class Decoration : IDecoration
    {
        public int Comfort { get; }

        public decimal Price { get; }
        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
    }
}
