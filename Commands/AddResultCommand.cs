using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Competitions.Models;
using Competitions.Services;
using Competitions.ViewModels;

namespace Competitions.Commands
{
    public class AddResultCommand : CommandBase
    {
        private readonly AddResultViewModel _addResult;
        private readonly Section _section;
        private readonly NavigationService _resultViewNavigationService;

        public AddResultCommand(AddResultViewModel addResult, 
            Section section, 
            NavigationService resultViewNavigationService)
        {
            _addResult = addResult;
            _section = section;
            this._resultViewNavigationService = resultViewNavigationService;
            _addResult.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddResultViewModel.Name) ||
                e.PropertyName == nameof(AddResultViewModel.ResultValue) ||
                e.PropertyName == nameof(AddResultViewModel.Exercise)) {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            Result result = new(_addResult.ResultValue, _addResult.Exercise);

            try
            {
                _section.GetAthleteByName(_addResult.Name).AddResult(result);
                MessageBox.Show("Result was added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _resultViewNavigationService.Navigate(Pages.BestResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addResult.Name) &&
                !string.IsNullOrEmpty(_addResult.Exercise) &&
                _addResult.ResultValue >= 0 &&
                base.CanExecute(parameter);
        }
    }
}
