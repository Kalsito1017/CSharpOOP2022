namespace FoodShortage.Models
{
    using _06._Food_Shortage;
    using Interfaces;
    public class Rebel : IBuyer, IIdentifiable
    {
        private const int BoughtFood = 5;
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public int Food { get; private set; }
        public int BuyFood() => Food += BoughtFood;
    }
}