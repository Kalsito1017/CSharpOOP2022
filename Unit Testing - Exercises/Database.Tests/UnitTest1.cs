namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldCreateDatabaseWithUpTo16Int(int[] numbers)
        {
            //Arrange
            Database db = new Database(numbers);

            //Act
            int[] actualNumbers = db.Fetch();
            int[] expectedNumbers = numbers;

            int actualCount = db.Count;
            int expectedCount = numbers.Length;

            //Assert
            CollectionAssert.AreEqual(expectedNumbers, actualNumbers, "DB is created correctly!");
            Assert.That(actualCount, Is.EqualTo(expectedCount), "Returned count is correct!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorShouldThrowExceptionWithMoreThan16IntAndWithEmptyArray(int[] numbers)
        {
            //Act And Assert
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    Database db = new Database(numbers);
                }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldAddUpTo16ElementsInDatabase(int[] numbers)
        {
            //Act
            foreach (int number in numbers)
            {
                this.database.Add(number);
            }

            int[] actualNumbers = this.database.Fetch();
            int[] expectedNumbers = numbers;

            int actualCount = this.database.Count;
            int expectedCount = numbers.Length;

            //Assert
            CollectionAssert.AreEqual(expectedNumbers, actualNumbers, "Add method works correctly!");
            Assert.That(actualCount, Is.EqualTo(expectedCount), "Returned count is correct!");
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldThrowExceptionWithMoreThan16Numbers(int[] numbers)
        {
            //Arrange
            foreach (int number in numbers)
            {
                this.database.Add(number);
            }

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveMethodShouldRemoveLastElementFromDB(int[] numbers)
        {
            //Arrange
            Database testDB = new Database(numbers);

            //Act
            testDB.Remove();

            int[] actualDB = testDB.Fetch();
            List<int> expectedDB = new List<int>(numbers);
            expectedDB.RemoveAt(numbers.Length - 1);

            int actualCount = testDB.Count;
            int expectedCount = expectedDB.Count;

            //Assert
            CollectionAssert.AreEqual(expectedDB, actualDB, "Remove method should remove the last element!");
            Assert.AreEqual(expectedCount, actualCount, "Count should return actual cpount of elements!");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDB()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchMethodShouldReturnDBAsArray(int[] numbers)
        {
            //Arrange
            Database testDB = new Database(numbers);

            //Act
            int[] actualDB = testDB.Fetch();
            int[] expectedDB = numbers;

            //Assert
            CollectionAssert.AreEqual(expectedDB, actualDB, "Fetch method should return DB as an array!");
        }
    }
}