using System;
namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double InitialArmorThickness = 300;
        private const double MainWeaponCaliberDifference = 40;
        private const double SpeedDifference = 5;
        public bool SonarMode { get; private set; }

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SonarMode = false;
        }

        public override void RepairVessel()
        {
            throw new NotImplementedException();
        }
        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
                MainWeaponCaliber -= MainWeaponCaliberDifference;
                Speed -= SpeedDifference;
            }
            else
            {
                SonarMode = true;
                MainWeaponCaliber += MainWeaponCaliberDifference;
                Speed -= SpeedDifference;
            }
        }
        public override string ToString()
         => base.ToString() + $" *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
    }
}
