namespace FoodShortage.Models
{
    using _06._Food_Shortage;
    using Interfaces;
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private const int BoughtFood = 10;
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }
        public string BirthDate { get; }

        public Citizen(string id, string name, int age, string birthDate)
        {
            Id = id;
            Name = name;
            Age = age;
            BirthDate = birthDate;
            Food = 0;
        }

        public int Food { get; private set; }
        public int BuyFood() => Food += BoughtFood;
    }
}