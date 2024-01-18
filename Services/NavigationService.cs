using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Stores;
using Competitions.ViewModels;

namespace Competitions.Services
{
    public class NavigationService
    {
        private readonly NavigationStore? _navigationStore;

        //private readonly Func<ViewModelBase> _createViewModel;

        private Func<ViewModelBase>? _createNavigationViewModel;
        public Func<ViewModelBase>? CreateNavigationViewModel
        {
            get => _createNavigationViewModel;

            set
            {
                _createNavigationViewModel = value;
            }
        }
        private Func<ViewModelBase>? _createAddResultViewModel;
        public Func<ViewModelBase>? CreateAddResultViewModel
        {
            get => _createAddResultViewModel;

            set
            {
                _createAddResultViewModel = value;
            }
        }
        private Func<ViewModelBase>? _createAddAthleteViewModel;
        public Func<ViewModelBase>? CreateAddAthleteViewModel
        {
            get => _createAddAthleteViewModel;

            set
            {
                _createAddAthleteViewModel = value;
            }
        }
        private Func<ViewModelBase>? _createConcreteResultsViewModel;
        public Func<ViewModelBase>? CreateConcreteResultsViewModel
        {
            get => _createConcreteResultsViewModel;

            set
            {
                _createConcreteResultsViewModel = value;
            }
        }

        private Func<ViewModelBase>? _createBestResultsViewModel;
        public Func<ViewModelBase>? CreateBestResultsViewModel
        {
            get => _createBestResultsViewModel;

            set
            {
                _createBestResultsViewModel = value;
            }
        }

        private Func<ViewModelBase>? _createResultsNavigationViewModel;
        public Func<ViewModelBase>? CreateResultsNavigationViewModel
        {
            get => _createResultsNavigationViewModel;

            set
            {
                _createResultsNavigationViewModel = value;
            }
        }


        public NavigationService(NavigationStore? navigationStore) // маленькая фабрика
        {
            this._navigationStore = navigationStore;
        }
        public void Navigate(Pages page)
        {
            switch(page)
            {
                case Pages.Navigation:
                    {
                        _navigationStore.CurrentViewModel = CreateNavigationViewModel();
                    }
                    break;
                case Pages.AddResult:
                    {
                        _navigationStore.CurrentViewModel = CreateAddResultViewModel();
                    }
                    break;
                case Pages.AddAthlete:
                    {
                        _navigationStore.CurrentViewModel = CreateAddAthleteViewModel();
                    }
                    break;
                case Pages.ConcreteResults:
                    {
                        _navigationStore.CurrentViewModel = CreateConcreteResultsViewModel();
                    }
                    break;
                case Pages.BestResults:
                    {
                        _navigationStore.CurrentViewModel = CreateBestResultsViewModel();
                    }
                    break;
                case Pages.ResultsNavigation:
                    {
                        _navigationStore.CurrentViewModel = CreateResultsNavigationViewModel();
                    }
                    break;
                default:
                    {
                        _navigationStore.CurrentViewModel = CreateNavigationViewModel();
                    }
                    break;

            }
        }
    }
}
