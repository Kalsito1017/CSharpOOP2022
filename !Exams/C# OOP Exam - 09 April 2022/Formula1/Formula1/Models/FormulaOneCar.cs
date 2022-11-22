

namespace Formula1.Models
{
using System;
using Formula1.Models.Contracts;
using Formula1.Utilities;
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.model = model;
            this.horsepower = horsepower;
            this.engineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value;
            }
        }
        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsepower = value;
            }
        }
        public double EngineDisplacement
        {
            get { return this.engineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2.0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
            }
        }
        public double RaceScoreCalculator(int laps)
       => this.EngineDisplacement / Horsepower * laps;

    }
}
