using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private Room room;
        
        [SetUp]
        public void Setup()
        {
            room = new Room(2, 25.0);
            hotel = new Hotel("HotelName", 3);
        }
         // TESTING CLASS ROOM
        [Test]
        public void Room_Constructor_SettingCorectly()
        {
            int bedCapacity = 2;
            double pricePerNight = 24.5;
            room = new Room(bedCapacity, pricePerNight);
            Assert.IsTrue(room.BedCapacity == bedCapacity && room.PricePerNight == pricePerNight);
        }
        [TestCase(-50)]
        [TestCase(0)]
        public void Room_PropertyBedCapacity_CantBeNegativeOrZero(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(bedCapacity, 35.0));
        }

        [TestCase(-5.5)]
        [TestCase(0.0)]
        public void Room_PropertyPricePerNight_CantBeNegativeOrZero(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() => room = new Room(2, pricePerNight));
        }
        //Testing class Booking
        [Test]
        public void Booking_Constructor_SettingCorreclty()
        {
             int bookingNumber = 10;
             int residenceDuration = 4;
            Booking booking = new Booking(bookingNumber,room, residenceDuration);
            Assert.True(booking.BookingNumber == bookingNumber && booking.ResidenceDuration == residenceDuration
                && booking.Room.Equals(room));
        }
        //TESTING CLASS HOTEL
        [Test]
        public void Hotel_Constructor_SettingCorectly()
        {
            string Hotel_Name = "Kalsito";
            int category = 4;
            hotel = new Hotel(Hotel_Name,category);
            Assert.IsTrue(hotel.FullName == Hotel_Name 
                && hotel.Category == category 
                && hotel.Rooms != null 
                && hotel.Bookings != null);
        }
        [TestCase(null)]
        [TestCase(" ")]
        public void Hotel_Property_CannotBe_Null_OrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(name, 4));
        }
        [TestCase(0)]
        [TestCase(4)]
        public void Hotel_Property_MustBeBetween1and5(int category)
        {
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("HotelName", category));
        }
        [Test]
        public void Hotel_AddRom_IncreaseCount()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(hotel.Rooms.Count, 1);
        }
        [TestCase(-4)]
        [TestCase(0)]
        public void Hotel_BookingRoom_Adults_CantBeNegativeOrZero(int adults)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2 ,4 , 500.0));
        }
        [TestCase(-1)]
        public void Hotel_BookingRoom_Children_CantBeNegativeOrZero(int children)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom( 2,children, 4, 500.0));
        }
        [TestCase(0)]
        public void Hotel_BookingRoom_RecidenseDurationCannotBeLessThan1(int recidenseDuration)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 3, recidenseDuration, 500.0));
        }
        [Test]
        public void Hotel_Booking_Room_AddsBookingToTheCollection()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 1);
        }
        [Test]
        public void Hotel_BookingRoom_DoesntBookIFBEDCAPACITYISLOWERTHANBEDSNEEDED()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 1, 4, 200.0);
            Assert.AreEqual(hotel.Bookings.Count, 0);
        }
        [Test]
        public void Hotel_BookingRoom_ProperlyGeneratesTurnOver()
        {
            int residenceDuration = 4;
            double pricePerNight = room.PricePerNight;
            double expectedTurnover = residenceDuration * pricePerNight;

            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, residenceDuration, 200.0);
            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }
    }
}