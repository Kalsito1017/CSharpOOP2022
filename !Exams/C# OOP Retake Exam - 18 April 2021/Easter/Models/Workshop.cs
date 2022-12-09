using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;
namespace Easter.Models
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (IDye dye in bunny.Dyes.Where(d => !d.IsFinished()))
            {
                while (!dye.IsFinished())
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (bunny.Energy == 0 || egg.IsDone())
                    {
                        break;
                    }
                }

                if (bunny.Energy == 0 || egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
