using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Exceptions;

namespace Competitions.Models
{
    public class Sportsmen
    {
        private readonly List<Result> _results = new List<Result>();
        public SportsmenID SportsmenID { get; }
        public string Name { get; }

        public Sportsmen(SportsmenID sportsmenID, string name)
        {
            SportsmenID = sportsmenID;
            Name = name;
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
    }
}
