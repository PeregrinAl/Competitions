using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Exceptions;

namespace Competitions.Models
{
    public class Result
    {
        public Exercice Exercice;
        public double? ResultValue { get; }

        public Result(double? ResultValue, string? ExerciseName)
        {
            this.ResultValue = ResultValue;
            this.Exercice = new Exercice(ExerciseName);
        }
        public bool Conflicts(Result result)
        {
            if (result.Exercice.Name != Exercice.Name)
            {
                return false;
            }
            return true;
        }
    }
}
