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
        private readonly Sportsmen _sportsmen;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _sportsmen = new Sportsmen(new SportsmenID(0), "Sasha Parshintseva");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateShowResultsModel();
            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddResult CreateAddResultViewModel() {
            return new AddResult(_sportsmen, new NavigationService(_navigationStore, CreateShowResultsModel));
        }
        private ShowResults CreateShowResultsModel() {
            return new ShowResults(_sportsmen, new NavigationService(_navigationStore, CreateAddResultViewModel));
        }
    }

}
