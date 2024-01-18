using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Competitions.Models;
using Competitions.Services;
using Competitions.ViewModels;
using Competitions.Views;

namespace Competitions.Commands
{
    internal class AddAthleteCommand : CommandBase
    {
        private readonly AddAthleteViewModel _addAthlete;
        private readonly Section _section;
        private readonly NavigationService _mainWindowNavigationService;

        public AddAthleteCommand(AddAthleteViewModel addAthlete,
            Section section,
            NavigationService mainWindowNavigationService)
        {
            _addAthlete = addAthlete;
            _section = section;
            this._mainWindowNavigationService = mainWindowNavigationService;
            _addAthlete.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddAthleteViewModel.Name) ||
                e.PropertyName == nameof(AddAthleteViewModel.WeaponType))
            {
                OnCanExecutedChanged();
            }
        }
        public override void Execute(object? parameter)
        {
            AthletesFactory athletesFactory = new AthletesFactory(_section);

            try
            {
                _section.AddAthlete(athletesFactory.createAthlete(_addAthlete.Name, _addAthlete.WeaponType));
                MessageBox.Show("Athlete was added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _mainWindowNavigationService.Navigate(Pages.Navigation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addAthlete.Name) &&
                !string.IsNullOrEmpty(_addAthlete.WeaponType) &&
                base.CanExecute(parameter);
        }

    }
}
