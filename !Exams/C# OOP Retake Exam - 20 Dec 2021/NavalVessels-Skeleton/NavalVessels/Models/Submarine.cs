using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const double InitialArmorThickness = 200;
        private const double MainWeaponCaliberDifference = 40;
        private const double SpeedDifference = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= MainWeaponCaliberDifference;
                Speed += SpeedDifference;
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += MainWeaponCaliberDifference;
                Speed -= SpeedDifference;
            }
        }
        public override void RepairVessel()
            => ArmorThickness = InitialArmorThickness;
        public override string ToString()
            => base.ToString() + $" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
    }
}
