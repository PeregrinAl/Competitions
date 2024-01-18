using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competitions.Models
{
    public class Section
    {
        private readonly List<Athlete> _athletes = new List<Athlete>();
        public Section() { }

        public IEnumerable<Athlete> ShowAthletes()
        {
            return _athletes;
        }
        public void AddAthlete(Athlete athlete)
        {
            _athletes.Add(athlete);
        }
        public Athlete? GetAthleteByName(string name)
        {
            return (_athletes.Find(x => x.Name == name));
        }
    }
}
