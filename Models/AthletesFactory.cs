using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competitions.Models
{
    public class AthletesFactory
    {
        private readonly Section _section;
        public AthletesFactory(Section section) {
            this._section = section;
        }
        public Athlete createAthlete(string Name, string WeaponType) {
            AthleteID athleteID = new AthleteID(0);
            foreach (var athlete in _section.ShowAthletes()) {
                if (athlete.Name == Name) {
                    return athlete;
                }
            }
            return new Athlete(athleteID, Name, WeaponType);
        }
    }
}
