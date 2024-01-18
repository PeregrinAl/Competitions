using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Stores;
using Competitions.ViewModels;

namespace Competitions.Services
{
    public class NavigationServiceBuilder
    {
        private readonly NavigationStore? _navigationStore;
        private readonly NavigationService _navigationService;

        public NavigationServiceBuilder(NavigationStore? navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationService = new NavigationService(navigationStore);
        }

        public NavigationServiceBuilder setNavigationViewModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateNavigationViewModel = createNewViewModel;
            return this;
        }
        public NavigationServiceBuilder setAddResultViewModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateAddResultViewModel = createNewViewModel;
            return this;
        }
        public NavigationServiceBuilder setAddAthleteViewModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateAddAthleteViewModel = createNewViewModel;
            return this;
        }

        public NavigationServiceBuilder setConcreteResultsViewModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateConcreteResultsViewModel = createNewViewModel;
            return this;
        }

        public NavigationServiceBuilder setShowBestResultsModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateBestResultsViewModel = createNewViewModel;
            return this;
        }

        public NavigationServiceBuilder setResultsNavigationViewModelDelegate(Func<ViewModelBase> createNewViewModel)
        {
            _navigationService.CreateResultsNavigationViewModel = createNewViewModel;
            return this;
        }

        public NavigationService buildService()
        {
            return _navigationService;
        }

    }
}
