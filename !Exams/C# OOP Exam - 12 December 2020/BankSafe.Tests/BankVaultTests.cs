using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item1;
        private Item item2;
        private BankVault vault;
             
        [SetUp]
        public void Setup()
        {
            this.item1 = new Item("Ivan", "1234");
            this.item2 = new Item("Kalsito", "5678");
            this.vault = new BankVault();
        }

        [Test]
        public void AddItemMethodShouldBeCorrectly()
        {
            string result = this.vault.AddItem("A1", this.item1);
            Assert.AreEqual(1, this.vault.VaultCells.Values.Count(v => v != null));
            Assert.AreEqual(item1.Owner, this.vault.VaultCells["A1"].Owner);
            Assert.AreEqual(item1.ItemId, this.vault.VaultCells["A1"].ItemId);
            Assert.AreEqual(item1.ItemId, this.vault.VaultCells["A1"].ItemId);
            Assert.AreEqual($"Item:{this.item1.ItemId} saved successfully!", result);
        }
        [Test]
        public void AddItemMethodShouldThrowAnException()
        {
            //ACT
            //ASSERT
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("A10", this.item1);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void AddItemMethodShouldThrowAnExceptionWhereCellisNotNull()
        {
            //ACT
            this.vault.AddItem("A1", this.item1);
            //ASSERT
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("A10", this.item2);
            }, "Cell is already taken!");
        }
        [Test]
        public void AddItemMethodShouldThrowAnExceptionWhithSameID()
        {
            //ACT
            this.vault.AddItem("A1", this.item1);
            //ASSERT
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.vault.AddItem("A2", this.item1);
            }, "Item is already in cell!");
        }
        [Test]
        public void RemoveItemMethodshouldRemoveITemCorrectly()
        {
            //ARRANGE
            this.vault.AddItem("A1", this.item1);
            //ACT
            string result = this.vault.RemoveItem("A1", this.item1);
            //ASSERT
            Assert.AreEqual(0, this.vault.VaultCells.Values.Count(v => v != null));
            Assert.IsNull(this.vault.VaultCells["A1"]);
            Assert.AreEqual($"Remove item:{this.item1.ItemId} successfully!", result);
        }
        [Test]
        public void RemoveItemMethodShouldThrowAnExcecptionWhenCellsDoesNotExists()
        {
            //Act                                  
            //ASSERT
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A10", this.item1);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void RemoveItemMethodShouldThrowAnExceptionWhenCellIsNullOrThereIsAnotherItemInIt()
        {
            //Act
            this.vault.AddItem("A1", this.item1);           
            //ASSERT
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A1", this.item2);
            }, "Item in that cell doesn't exists!");
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A2", this.item2);
            }, "Item in that cell doesn't exists!");
        }
    }
}