using System.Configuration;
using System.Data;
using System.Windows;
using Competitions.Commands;
using Competitions.Exceptions;
using Competitions.Models;
using Competitions.Services;
using Competitions.Stores;
using Competitions.ViewModels;

namespace Competitions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Section _section;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _section = new Section();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateNavigationViewModel();
            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationViewModel CreateNavigationViewModel() {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setAddResultViewModelDelegate(CreateAddResultViewModel)
                .setAddAthleteViewModelDelegate(CreateAddAthleteViewModel)
                .setResultsNavigationViewModelDelegate(CreateNavigationResultsViewModel)
                .buildService();
            return new NavigationViewModel(navigationService);

        }

        private BestResultsViewModel CreateShowBestResultsViewModel()
        {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setAddResultViewModelDelegate (CreateAddResultViewModel)
                .setNavigationViewModelDelegate(CreateNavigationViewModel)
                .setShowBestResultsModelDelegate(CreateShowBestResultsViewModel)
                .buildService();
            return new BestResultsViewModel(_section, navigationService);
        }

        private AddAthleteViewModel CreateAddAthleteViewModel()
        {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setNavigationViewModelDelegate(CreateNavigationViewModel)
                .buildService();
            return new AddAthleteViewModel(_section, navigationService);
        }

        private AddResultViewModel CreateAddResultViewModel()
        {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setShowBestResultsModelDelegate(CreateShowBestResultsViewModel)
                .setNavigationViewModelDelegate(CreateNavigationViewModel)
                .buildService();
            return new AddResultViewModel(_section, navigationService);
        }
        private ConcreteResultsViewModel CreateConcreteResultsViewModel()
        {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setAddResultViewModelDelegate(CreateAddResultViewModel)
                .setNavigationViewModelDelegate(CreateNavigationViewModel)
                .buildService();
            return new ConcreteResultsViewModel(new Athlete(new AthleteID(6), "Sasha", "vintovka"), navigationService); // TODO: 
        }

        private ResultsNavigationViewModel CreateNavigationResultsViewModel()
        {
            NavigationService navigationService = new NavigationServiceBuilder(_navigationStore)
                .setConcreteResultsViewModelDelegate(CreateConcreteResultsViewModel)
                .setShowBestResultsModelDelegate(CreateShowBestResultsViewModel)
                .buildService();
            return new ResultsNavigationViewModel(navigationService); // TODO: 
        }

    }

}
