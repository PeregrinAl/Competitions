using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Competitions.Models;

namespace Competitions.Exceptions
{
    internal class ResultAddException : Exception
    {        
        public Result ExistingSportsmen { get; }
        public Result IncomingSportsmen { get; }
        public ResultAddException(Result existingSportsmen, Result incomingSportsmen)
        {
            ExistingSportsmen = existingSportsmen;
            IncomingSportsmen = incomingSportsmen;
        }

        public ResultAddException(string? message, Result existingSportsmen, Result incomingSportsmen) : base(message)
        {
            ExistingSportsmen = existingSportsmen;
            IncomingSportsmen = incomingSportsmen;
        }

        public ResultAddException(string? message, Exception? innerException, Result existingSportsmen, Result incomingSportsmen) : base(message, innerException)
        {
            ExistingSportsmen = existingSportsmen;
            IncomingSportsmen = incomingSportsmen;
        }
    }
}
