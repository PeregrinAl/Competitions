using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Commands;
using Competitions.Services;
using System.Windows.Input;

namespace Competitions.ViewModels
{
    public class ResultsNavigationViewModel : ViewModelBase
    {
        public ICommand NavigateConcreteResultsCommand { get; }
        public ICommand NavigateBestResultsCommand { get; }
        public ResultsNavigationViewModel(NavigationService navigationService)
        {
            NavigateConcreteResultsCommand = new NavigateCommand(navigationService, Pages.ConcreteResults);
            NavigateBestResultsCommand = new NavigateCommand(navigationService, Pages.BestResults);
        }
    }
}
