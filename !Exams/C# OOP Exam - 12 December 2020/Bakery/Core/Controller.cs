using Bakery.Core.Contracts;
using Bakery.Models;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        decimal totalIncome = 0;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = type switch
            {
                nameof(Bread) => new Bread(name, price),
                nameof(Cake) => new Cake(name, price),
                _ => null
            };
            this.bakedFoods.Add(bakedFood);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                nameof(Tea) => new Tea(name, portion, brand),
                nameof(Water) => new Water(name, portion, brand),
                _ => null
            };
            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }


        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                nameof(InsideTable) => new InsideTable(tableNumber, capacity),
                nameof(OutsideTable) => new OutsideTable(tableNumber, capacity),
                _ => null
            };
            this.tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITable table in this.tables.Where(t => !t.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()

            => String.Format(OutputMessages.TotalIncome, totalIncome);


        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.First(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = this.drinks.FirstOrDefault(t => t.Name == drinkName && t.Brand == drinkBrand);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood food = this.bakedFoods.FirstOrDefault(t => t.Name == foodName);
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }


        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

          if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}

