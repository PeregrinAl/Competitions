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
        private readonly AddResult _addResult;
        private readonly Sportsmen _sportsmen;
        private readonly NavigationService _resultViewNavigationService;

        public AddResultCommand(AddResult addResult, 
            Sportsmen sportsmen, 
            NavigationService resultViewNavigationService)
        {
            _addResult = addResult;
            _sportsmen = sportsmen;
            this._resultViewNavigationService = resultViewNavigationService;
            _addResult.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddResult.Name) ||
                e.PropertyName == nameof(AddResult.ResultValue) ||
                e.PropertyName == nameof(AddResult.Exercise)) {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            Result result = new(_addResult.ResultValue, _addResult.Exercise);

            try
            {
                _sportsmen.AddResult(result);
                MessageBox.Show("Result was added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _resultViewNavigationService.Navigate();
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
