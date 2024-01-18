using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Exceptions;

namespace Competitions.Models
{
    public class Athlete
    {
        private readonly List<Result> _results = new List<Result>();
        public AthleteID AthleteID { get; }
        public string Name { get; }
        public string weaponType { get; }

        public Athlete(AthleteID athleteID, string name, string weaponType)
        {
            AthleteID = athleteID;
            Name = name;
            this.weaponType = weaponType;
        }
        public IEnumerable<Result> ShowResults()
        {
            return _results;
        }

        public void AddResult(Result result)
        {
            // Сюда можно вставить проверку
/*            foreach (Result existingResult in _results)
            {
                if (existingResult.Conflicts(result))
                {
                    throw new ResultAddException(existingResult, result);
                }
            }*/
            _results.Add(result);
        }

        public void DeleteResult(Result result)
        {
            _results.Remove(result);
        }
    }
}
