
namespace BookingApp.Models
{
    public class Apartment : Room
    {
        private const int InitialBedCapacity = 6;
        public Apartment() : base(InitialBedCapacity)
        {
        }
    }
}
