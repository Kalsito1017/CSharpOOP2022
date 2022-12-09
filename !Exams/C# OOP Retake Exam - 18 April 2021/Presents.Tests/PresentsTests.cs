namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;  //ma ik
        [Test]
        public void Setting_ConstructorProperly()
        {
            //shutup
            Bag bag = new Bag();
            Assert.That(bag, Is.Not.Null);  

        }
        [Test]
        public void Test_PresentIsNull()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }
        [Test]
        public void Test_PresentExists()
        {
            Bag bag = new Bag();
            Present present = new Present("Hehhea", 2);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void Test_AddCorrectly()
        {       
            Bag bag = new Bag();
            Present present = new Present("Hehhea", 2);

           var x = bag.Create(present).Split();
            Assert.AreEqual(present.Name + '.', x[3]);
            //$"Successfully added present {present.Name}.";
        }
        [Test]
        public void Test_AddCorr()
        {

            Bag bag = new Bag();
            Present present = new Present("Hehhea", 2);
            bag.Create(present);
            var x = bag.GetPresents();
            Assert.That(x.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test_REmove()
        {
            
            Bag bag = new Bag();
            Present present = new Present("Hehhea", 2);
            bag.Create(present);
            
            Assert.IsTrue(bag.Remove(present));
        }
        [Test]
        public void Test_REmovenegative()
        {

            Bag bag = new Bag();
            Present present = new Present("Hehhea", 2);
            

            Assert.IsFalse(bag.Remove(present));
        }
       
        [Test]
        public void Test_REmovenegativefe()
        {

            Present present = new Present("dgwg",1);
            Present present1 = new Present("124r123",2);
            Present present2 = new Present("12412", 3);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);
            var x = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(x, present);
        }
        [Test]
        public void Test_REmovenegativefesdfgsg()
        {
            Bag bag = new Bag();
            var x = bag.GetPresent("sdgwrgw");
            Assert.AreEqual(x, null);
        }
        [Test]
        public void Test_REmovenegativefesdfgsgdfgwgw()
        {
            Present present = new Present("gdsgsd",2);
            Bag bag = new Bag();
            bag.Create(present);
            var x = bag.GetPresent("gdsgsd");
            Assert.AreEqual(x, present);
        }
      
    }
}
