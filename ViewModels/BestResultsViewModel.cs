using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Commands;
using Competitions.Models;
using Competitions.Services;
using System.Windows.Input;

namespace Competitions.ViewModels
{
    public class BestResultsViewModel : ViewModelBase
    {
        private readonly Section _section;
        private readonly ObservableCollection<ResultViewModel> _results;
        private readonly NavigationService _bestResultsNavigationService;
        public IEnumerable<ResultViewModel> Results => _results;
        public ICommand? AddResultCommand { get; }
        public ICommand? CancelCommand { get; }
        public BestResultsViewModel(Section section, NavigationService BestResultsNavigationService)
        {
            _section = section;
            _results = new ObservableCollection<ResultViewModel>();
            _bestResultsNavigationService = BestResultsNavigationService;

            AddResultCommand = new NavigateCommand(BestResultsNavigationService, Pages.AddResult);
            CancelCommand = new NavigateCommand(BestResultsNavigationService, Pages.Navigation);

            UpdateResults();
        }

        private void UpdateResults()
        {
            _results.Clear();

            foreach (Athlete athlete in _section.ShowAthletes())
            {
                foreach (Result result in athlete.ShowResults())
                {
                    ResultViewModel resultViewModel = new ResultViewModel(result, athlete, _bestResultsNavigationService);
                    _results.Add(resultViewModel);
                }
            }
        }
    }
}
