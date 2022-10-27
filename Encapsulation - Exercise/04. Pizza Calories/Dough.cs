using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Pizza_Calories
{
    public class Dough
    {
        private const double StartCalories = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourType = flourType;
            this.bakingTechnique = bakingTechnique;
            this.weight = weight;
        }
        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public double GetTotalCalories()
        {
            return StartCalories * Weight * Modifiers.GetCalsByFlourType(FlourType) * Modifiers.GetCalsByBakingTechnique(BakingTechnique);
        }
    }
}
