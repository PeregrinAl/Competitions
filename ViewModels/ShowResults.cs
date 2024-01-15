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
    public class ShowResults : ViewModelBase
    {
        private readonly Sportsmen _sportsmen;
        private readonly ObservableCollection<ResultViewModel> _results;
        public IEnumerable<ResultViewModel> Results => _results;
        public ICommand? AddResultCommand { get; }
        public ShowResults(Sportsmen sportsmen, NavigationService AddResultNavigationService)
        {
            _sportsmen = sportsmen;
            _results = new ObservableCollection<ResultViewModel>();

            AddResultCommand = new NavigateCommand(AddResultNavigationService);

            UpdateResults();
        }

        private void UpdateResults()
        {
            _results.Clear();

            foreach (Result result in _sportsmen.ShowResults())
            {
                ResultViewModel resultViewModel = new ResultViewModel(result, _sportsmen);
                _results.Add(resultViewModel);
            }
        }
    }
}
