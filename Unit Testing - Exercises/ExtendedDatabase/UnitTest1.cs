namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database databaseEmpty;
        private Database databaseTest;

        [SetUp]
        public void SetUp()
        {
            this.databaseEmpty = new Database();
            this.databaseTest = new Database(FillPersonArray(15));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(16)]
        public void ConstructorShouldCreateDatabase(int count)
        {
            //Arrange
            Database database = new Database(FillPersonArray(count));

            //Act            
            int actualCount = database.Count;
            int expectedCount = count;

            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount), "Constructor should cteate DB with correct count of persons");
        }

        [TestCase(17)]
        public void ConstructorShouldThrowAnExceptionWithMoreThan16Persons(int count)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(FillPersonArray(count));

            }, "Provided data length should be in range [0..16]!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(15)]
        public void AddMethodShouldAddPersonAtLastPosition(int count)
        {
            //Arrange
            Database database = new Database(FillPersonArray(count));
            Person me = new Person(3411, "Ivs");

            //Act
            database.Add(me);

            int actualCount = database.Count;
            int expectedCount = count + 1;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "Add method should increase the count of elements in DB");
        }

        [TestCase(16)]
        public void AddMethodShouldThrowAnExceptionWithMoreThan16Person(int count)
        {
            //Arrange
            Database database = new Database(FillPersonArray(count));
            Person me = new Person(3411, "Ivs");

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(me);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase("Ivs")]
        [TestCase(" ")]
        public void AddMethodShouldThrowAnExceptionWhenInDBExistUserWithSameUsername(string username)
        {
            //Arrange            
            Person me = new Person(3411, username);
            Person otherMe = new Person(341134, username);

            //Act
            this.databaseEmpty.Add(me);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.databaseEmpty.Add(otherMe);
            }, "There is already user with this username!");
        }

        [TestCase(3411)]
        [TestCase(9223372036854775807)]
        public void AddMethodShouldThrowAnExceptionWhenInDBExistUserWithSameID(long id)
        {
            //Arrange
            Person me = new Person(id, "Ivs");
            Person otherMe = new Person(id, "Iveto");

            //Act
            this.databaseEmpty.Add(me);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.databaseEmpty.Add(otherMe);
            }, "There is already user with this Id!");
        }

        [TestCase(1)]
        [TestCase(16)]
        [TestCase(2)]
        public void RemoveMethodShouldRemoveLastElementFromDB(int count)
        {
            //Arrange
            Database database = new Database(FillPersonArray(count));

            //Act
            database.Remove();

            int actualCount = database.Count;
            int expectedCount = count - 1;

            //Assert           
            Assert.AreEqual(expectedCount, actualCount, "Count should return actual cpount of elements!");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDB()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.databaseEmpty.Remove();
            }, "The collection is empty!");
        }

        [TestCase("Ivs")]
        public void FindByUsernameMethodShouldReturnTheUserWithSameUsername(string username)
        {
            //Arrange
            Person me = new Person(3411, username);
            this.databaseTest.Add(me);

            //Act
            Person actual = this.databaseTest.FindByUsername(username);
            Person expected = me;

            //Assert
            Assert.AreEqual(expected, actual, "The method FindByUsername return the user correctly!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodShouldThrowAnExceptionWithNullOrEmptyUsername(string username)
        {
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Person person = this.databaseTest.FindByUsername(username);
            }, "Username parameter is null!");
        }

        [TestCase("Ivs")]
        public void FindByUsernameMethodShouldThrowAnExceptionWhenUsernameByThisNameDoesNotExistInDB(string username)
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = this.databaseTest.FindByUsername(username);
            }, "No user is present by this username!");
        }

        [TestCase("Ivs")]
        public void FindByUsernameMethodShouldThrowAnExceptionWhenUsernameByThisNameDoesNotExistInDBCaseSensitive(string username)
        {
            //Arrange
            Person person = new Person(1000, username);
            this.databaseTest.Add(person);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person personToFind = this.databaseTest.FindByUsername(username.ToLower());
            }, "No user is present by this username!");

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person personToFind = this.databaseTest.FindByUsername(username.ToUpper());
            }, "No user is present by this username!");
        }

        [TestCase(3411)]
        public void FindByIdMethodShouldReturnTheUserWithSameID(long id)
        {
            //Arrange
            Person me = new Person(id, "Ivs");
            this.databaseTest.Add(me);

            //Act
            Person actual = this.databaseTest.FindById(id);
            Person expected = me;

            //Assert
            Assert.AreEqual(expected, actual, "The method FindById return the user correctly!");
        }

        [TestCase(-1)]
        [TestCase(-8)]
        public void FindByIdMethodThrowAnExceptionWhenIdIsNegativeOrZero(long id)
        {
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person person = this.databaseTest.FindById(id);
            }, "Id should be a positive number!");
        }

        [TestCase(1000)]
        [TestCase(80)]
        public void FindByIdMethodThrowAnExceptionWhenUserWithIdDoesNotExist(long id)
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = this.databaseTest.FindById(id);
            }, "No user is present by this ID!");
        }

        private static Person[] FillPersonArray(int count)
        {
            Person[] persons = new Person[count];
            for (int i = 0; i < count; i++)
            {
                persons[i] = new Person(i, "a" + i);
            }
            return persons;
        }
    }
}