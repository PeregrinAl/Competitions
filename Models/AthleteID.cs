using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Competitions.Models
{
    public class AthleteID
    {
        public AthleteID(int id)
        {
            ID = id;
        }

        public int ID { get; }
        public override bool Equals(object? obj)
        {
            return obj is AthleteID athleteID &&
                athleteID.ID == ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public static bool operator ==(AthleteID athleteId1, AthleteID athleteId2)
        {
            if (athleteId1 is null && athleteId2 is null)
            {
                return true;
            }

            return !(athleteId1 is null) && athleteId1.Equals(athleteId2);
        }
        public static bool operator !=(AthleteID athleteId1, AthleteID athleteId2)
        {
            return !(athleteId1 == athleteId2);
        }

        public override string? ToString()
        {
            return $"{ID}";
        }
    }
}
