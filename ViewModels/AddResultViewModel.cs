using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Competitions.Commands;
using Competitions.Models;
using Competitions.Services;

namespace Competitions.ViewModels
{
    public class AddResultViewModel : ViewModelBase
    {
        private readonly Section _section;
        private readonly ObservableCollection<String> _athletes;
        public IEnumerable<String> Athletes => _athletes;
        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _exercise;
        public string? Exercise
        {
            get => _exercise;
            set
            {
                _exercise = value;
                OnPropertyChanged(nameof(Exercise));
            }
        }

        private double? _resultValue;
        public double? ResultValue
        {
            get
            => _resultValue;
            set
            {
                _resultValue = value;
                OnPropertyChanged(nameof(ResultValue));
            }
        }

        public ICommand AddResultCommand { get; }
        public ICommand CancelCommand { get; }
        public AddResultViewModel(Section section, NavigationService resultViewNavigationService)
        {
            AddResultCommand = new AddResultCommand(this, section, resultViewNavigationService); // TODO:
            CancelCommand = new NavigateCommand(resultViewNavigationService, Pages.Navigation);

            this._section = section;
            _athletes = new ObservableCollection<String>();
            UpdateAthletes();
        }
        private void UpdateAthletes()
        {
            _athletes.Clear();

            foreach (Athlete athlete in _section.ShowAthletes())
            {
                _athletes.Add(athlete.Name);
            }
        }

    }
}
