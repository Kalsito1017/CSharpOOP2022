using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;
        public Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
            
        }
        public int BedCapacity => bedCapacity;

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
