
namespace BookingApp.Models
{
    public class DoubleBed : Room
    {
        private const int InitialBedCapacity = 2;
        public DoubleBed() : base(InitialBedCapacity)
        {
        }
    }
}
