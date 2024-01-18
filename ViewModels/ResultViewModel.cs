using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Competitions.Commands;
using Competitions.Models;
using Competitions.Services;

namespace Competitions.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly Result _result;
        private readonly Athlete _athlete;
        private readonly NavigationService? _deleteResultNavigationService;
        public String Exercise => _result.Exercice.ToString();
        public String? ResultValue => _result.ResultValue.ToString();
        public String Name => _athlete.Name;
        public ICommand? DeleteResultCommand { get; }
        public ResultViewModel(Result result, Athlete athlete, NavigationService? deleteResultNavigationService)
        {
            this._result = result;
            this._athlete = athlete;
            DeleteResultCommand = new DeleteResultCommand(athlete, result, deleteResultNavigationService);
        }
    }
}
