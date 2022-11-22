using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    
    public class SmartphoneShopTests
    {
        private const string PhoneModel = "NOKIA";
        private const int PhoneCHarge = 100;
        private const int ShopCapacity = 2;
        private Smartphone phone;
        private Shop shop;
        [SetUp]
       public void SetUp()
        {
            phone = new Smartphone(PhoneModel, PhoneCHarge);
            shop = new Shop(ShopCapacity);
        }
        public void Phone_Constructor_CreatesProp()
        {
            int expectedcurrcharge = PhoneCHarge;
            Assert.True(phone.ModelName == PhoneModel && phone.CurrentBateryCharge == expectedcurrcharge 
                && phone.MaximumBatteryCharge == PhoneCHarge);
        }
       [Test]
       public void Shop_Constructor_CreatesProp()
        {
            Assert.True(shop.Capacity == ShopCapacity);
        }
        [Test]
         public void Shop_Add_IncreaseCount()
        {
            shop.Add(phone);
            Assert.AreEqual(shop.Count, 1);
        }
        [Test]
        public void Shop_Add_ThrowsForExistingPhone()
        {
            shop.Add(phone);
            Assert.Throws < InvalidOperationException>(() => shop.Add(new Smartphone(PhoneModel, 0)));
        }
        [Test]
        public void Shop_Add_ThrowsForNonExistingPhone()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Fake phone model"));
        }
        [Test]
        public void Shop_Add_ThrowsForFullCapacity()
        {
            Smartphone phone2 = new Smartphone("Token phone 1", PhoneCHarge);
            Smartphone phone3 = new Smartphone("Token phone 2", PhoneCHarge);
            shop.Add(phone);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone3));
        }
        [Test]
        public void Shop_Remove_DecreasesCount()
        {
            shop.Add(phone);
            shop.Remove(phone.ModelName);
            Assert.AreEqual(shop.Count, 0);
        }
        [Test]
        public void Shop_Remove_ThrowsForNonExistentModel()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Missing mode", 40));
        }
        [Test]
        public void Shop_Remove_ThrowsForLowBattery()
        {
            shop.Add(phone);
            int testUsage = PhoneCHarge + 10;
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(PhoneModel, testUsage));
        }
        [Test]
        public void Shop_TestPhone_DecreasesBatteryChargeProperly()
        {
            int testUsage = 40;
            int expectedCharge = PhoneCHarge - testUsage;
            shop.Add(phone);
            shop.TestPhone(PhoneModel, testUsage);
            Assert.AreEqual(phone.CurrentBateryCharge, expectedCharge);
        }
        [Test]
        public void Shop_ChargePhone_RefillsBatteryChargeToMaximum()
        {
            int testUsage = 20;
            shop.Add(phone);
            shop.TestPhone(PhoneModel, testUsage);
            shop.ChargePhone(PhoneModel);
            Assert.AreEqual(phone.CurrentBateryCharge, PhoneCHarge);
        }
        [Test]
        public void Shop_ChargePhone_ThrowsForNonExistentModel()
        {          
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Misiing model"));
        }
    }
}