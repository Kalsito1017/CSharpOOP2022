
namespace BookingApp.Models
{
    public class Studio : Room
    {
        private const int InitialBedCapacity = 4;
        public Studio() : base(InitialBedCapacity)
        {
        }
    }
}
