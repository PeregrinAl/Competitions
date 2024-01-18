using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Competitions.Commands;
using Competitions.Models;
using Competitions.Services;
using Competitions.Stores;

namespace Competitions.ViewModels
{
    public class ConcreteResultsViewModel : ViewModelBase
    {
        private readonly Athlete _athlete;
        private readonly ObservableCollection<ResultViewModel> _results;
        private readonly NavigationService _addResultNavigationService;
        public IEnumerable<ResultViewModel> Results => _results;
        public ICommand? AddResultCommand { get; }
        public ICommand? CancelCommand { get; }
        public ConcreteResultsViewModel(Athlete athlete, NavigationService AddResultNavigationService)
        {
            _athlete = athlete;
            _results = new ObservableCollection<ResultViewModel>();
            _addResultNavigationService = AddResultNavigationService;

            AddResultCommand = new NavigateCommand(AddResultNavigationService, Pages.AddResult);
            CancelCommand = new NavigateCommand(AddResultNavigationService, Pages.Navigation);

            UpdateResults();
        }

        private void UpdateResults()
        {
            _results.Clear();

            foreach (Result result in _athlete.ShowResults())
            {
                ResultViewModel resultViewModel = new ResultViewModel(result, _athlete, _addResultNavigationService);
                _results.Add(resultViewModel);
            }
        }
    }
}
