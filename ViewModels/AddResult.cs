using System;
using System.Collections.Generic;
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
    public class AddResult : ViewModelBase
    {
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
        private string? _results;
        public string? Results
        {
            get
            => _results;
            set
            {
                _results = value;
                OnPropertyChanged(nameof(ResultValue));
            }
        }

        public ICommand AddResultCommand { get; }
        public ICommand CancelCommand { get; }
        public AddResult(Sportsmen sportsmen, 
            NavigationService resultViewNavigationService)
        {
            AddResultCommand = new AddResultCommand(this, sportsmen, resultViewNavigationService);
            CancelCommand = new NavigateCommand(resultViewNavigationService);
        }

    }
}
