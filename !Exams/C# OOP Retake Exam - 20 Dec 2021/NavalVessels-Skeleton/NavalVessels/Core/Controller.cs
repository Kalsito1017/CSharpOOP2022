namespace NavalVessels.Core
{
      using NavalVessels.Core.Contracts;
       using NavalVessels.Models;
      using NavalVessels.Models.Contracts;
       using NavalVessels.Repositories;
       using NavalVessels.Utilities.Messages;
        using System.Collections.Generic;
        using System.Linq;
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;
        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.Models.Any(v => v.Name == name))
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            IVessel vessel;
            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(s => s.FullName == selectedCaptainName);
            IVessel vessel = this.vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }
        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.First(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVesel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);
            if (attackingVesel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVesel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            attackingVesel.Attack(defendingVessel);
            attackingVesel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
               defendingVessel.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            if (vessel.GetType().Name == nameof(Battleship))
            {
                Battleship battleship = vessel as Battleship;
                battleship?.ToggleSonarMode();

            }
            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vesel = this.vessels.FindByName(vesselName);
            return vesel.ToString();
        }
    }
}
