using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Competitions.Commands;
using Competitions.Services;

namespace Competitions.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public ICommand NavigateAddResultCommand { get; }
        public ICommand NavigateResultsNavigationCommand { get; }
        public ICommand NavigateAddAthleteCommand { get; }
        public NavigationViewModel(NavigationService navigationService) {
            NavigateAddResultCommand = new NavigateCommand(navigationService, Pages.AddResult);
            NavigateResultsNavigationCommand = new NavigateCommand(navigationService, Pages.ResultsNavigation);
            NavigateAddAthleteCommand = new NavigateCommand(navigationService, Pages.AddAthlete);
        }
    }
}
