using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competitions.Commands;
using Competitions.Models;
using System.Windows.Input;
using Competitions.Services;

namespace Competitions.ViewModels
{
    public class AddAthleteViewModel : ViewModelBase
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

        private string? _weaponType;
        public string? WeaponType
        {
            get => _weaponType;
            set
            {
                _weaponType = value;
                OnPropertyChanged(nameof(WeaponType));
            }
        }

        private string? _athletes;
        public string? Athletes
        {
            get
            => _athletes;
            set
            {
                _athletes = value;
                OnPropertyChanged(nameof(Athletes));
            }
        }
        public ICommand AddAthleteCommand { get; }
        public ICommand CancelCommand { get; }
        public AddAthleteViewModel(Section section,
            NavigationService addAthleteViewNavigationService)
        {
            AddAthleteCommand = new AddAthleteCommand(this, section, addAthleteViewNavigationService);
            CancelCommand = new NavigateCommand(addAthleteViewNavigationService, Pages.Navigation);
        }

    }
}
