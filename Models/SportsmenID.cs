using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Competitions.Models
{
    public class SportsmenID
    {
        public SportsmenID(int id)
        {
            ID = id;
        }

        public int ID { get; }
        public override bool Equals(object? obj)
        {
            return obj is SportsmenID sportsmenID &&
                sportsmenID.ID == ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public static bool operator ==(SportsmenID sportsmenID1, SportsmenID sportsmenID2)
        {
            if (sportsmenID1 is null && sportsmenID2 is null)
            {
                return true;
            }

            return !(sportsmenID1 is null) && sportsmenID1.Equals(sportsmenID2);
        }
        public static bool operator !=(SportsmenID sportsmenID1, SportsmenID sportsmenID2)
        {
            return !(sportsmenID1 == sportsmenID2);
        }

        public override string? ToString()
        {
            return $"{ID}";
        }
    }
}
