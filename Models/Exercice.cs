using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Exceptions;

namespace Competitions.Models
{
    public class Exercice
    {
        public String? Name;
        public Exercice(String? name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
