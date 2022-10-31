namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        int Food { get; }
        int BuyFood();
    }
}