using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Modifiers
    {
        public static double GetCalsByFlourType(string flourType)
        {
            switch (flourType.ToLower())
            {
                case "white": return 1.5;
                case "wholegrain": return 1;
            }
            return 1;
        }
        public static double GetCalsByBakingTechnique(string bakingtechnique)
        {
            switch(bakingtechnique.ToLower())
            {
                case "chewy": return 1.1;
                case "crispy": return 0.9;
                case "homemade": return 1;
            }
            return 1;
        }
        public static double GetCalsByTopping(string topping)

        {
            switch (topping.ToLower())
            {
                case "meat": return 1.2;
                case "veggies": return 0.8;
                case "cheese": return 1.1;
                case "sauce": return 0.9;
            }
            return 1;
        }
    }
    
}
