using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Models;

namespace Competitions.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly Result _result;
        private readonly Sportsmen _sportsmen;
        public String Exercise => _result.Exercice.ToString();
        public String? ResultValue => _result.ResultValue.ToString();
        public String Name => _sportsmen.Name;
        public ResultViewModel(Result result, Sportsmen sportsmen)
        {
            this._result = result;
            this._sportsmen = sportsmen;
        }
    }
}
