using Automate.Interfaces;
using Automate.Utils;
using Microsoft.Xaml.Behaviors;
using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Automate.ViewModels
{
    class FarmingControlsViewModel : INotifyPropertyChanged
    {

        public Window Window { get; set; }
        private readonly NavigationService _navigationService;
        private readonly MongoDBService _mongoService;
        private static IWindowService? _windowService;
        
        public ICommand SaveCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ActionEclairageCommand { get; }
        public ICommand ActionFenetreCommand { get; }
        public ICommand ActionArrosageCommand { get; }
        public ICommand ActionChauffageCommand { get; }
        public ICommand ActionVentilateurCommand { get; }

        private float _temperatureControlleDe;
        private float _luminositeControlleDe;
        private float _humiditeControlleDe;
        private float _temperatureControlleA;
        private float _luminositeControlleA;
        private float _humiditeControlleA;
        private float _temperatureReelle;
        private float _luminositeReelle;
        private float _humiditeReelle;

        private bool _isActionVentilateur;
        private bool _isActionChauffage;
        private bool _isActionArrosage;
        private bool _isActionFenetre;
        private bool _isActionEclairage;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FarmingControlsViewModel(Window openedWindow)
        {
            _navigationService = new NavigationService();
            if (_mongoService is null)
                _mongoService = new MongoDBService("AutomateDB");

            if (_windowService is null)
                _windowService = WindowServiceWrapper.GetInstance(this, openedWindow, _navigationService);

            Window = openedWindow;

            SaveCommand = new RelayCommand(SaveValueClimatiques);
            LogoutCommand = new RelayCommand(Logout);
            ActionEclairageCommand = new RelayCommand(ActionEclairage);
            ActionFenetreCommand = new RelayCommand(ActionFenetre);
            ActionArrosageCommand = new RelayCommand(ActionArrosage);
            ActionChauffageCommand = new RelayCommand(ActionChauffage);
            ActionVentilateurCommand = new RelayCommand(ActionVentilateur);
           
        }

        private void ActionVentilateur(object obj)
        {
            IsActionVentilateur = !IsActionVentilateur;
        }

        private void ActionChauffage(object obj)
        {
            IsActionChauffage = !IsActionChauffage;
        }

        private void ActionArrosage(object obj)
        {
            IsActionArrosage = !IsActionArrosage;
        }

        private void ActionFenetre(object obj)
        {
            IsActionFenetre = !IsActionFenetre;
        }

        private void ActionEclairage(object obj)
        {
            IsActionEclairage = !IsActionEclairage;
        }

        private void SaveValueClimatiques(object obj)
        {
            throw new NotImplementedException();
        }

        private void Logout()
        {
            if(_windowService is not null)
                _windowService.Logout();
        }

        public bool IsActionVentilateur
        {
            get => _isActionVentilateur;
            set
            {
                if (_isActionVentilateur != value)
                {
                    _isActionVentilateur = value;
                    OnPropertyChanged(nameof(IsActionVentilateur));
                }
            }
        }

        public bool IsActionChauffage
        {
            get => _isActionChauffage;
            set
            {
                if (_isActionChauffage != value)
                {
                    _isActionChauffage = value;
                    OnPropertyChanged(nameof(IsActionChauffage));
                }
            }
        }

        public bool IsActionEclairage
        {
            get => _isActionEclairage;
            set
            {
                if (_isActionEclairage != value)
                {
                    _isActionEclairage = value;
                    OnPropertyChanged(nameof(IsActionEclairage));
                }
            }
        }

        public bool IsActionArrosage
        {
            get => _isActionArrosage;
            set
            {
                if (_isActionArrosage != value)
                {
                    _isActionArrosage = value;
                    OnPropertyChanged(nameof(IsActionArrosage));
                }
            }
        }


        public bool IsActionFenetre
        {
            get => _isActionFenetre;
            set
            {
                if (_isActionFenetre != value)
                {
                    _isActionFenetre = value;
                    OnPropertyChanged(nameof(IsActionFenetre));
                }
            }
        }


        public float TemperatureControlleDe
        {
            get => _temperatureControlleDe;
            set
            {
                if (_temperatureControlleDe != value)
                {
                    _temperatureControlleDe = value;
                    OnPropertyChanged(nameof(TemperatureControlleDe));
                }
            }
        }

        public float TemperatureControlleA
        {
            get => _temperatureControlleA;
            set
            {
                if (_temperatureControlleA != value)
                {
                    _temperatureControlleA = value;
                    OnPropertyChanged(nameof(TemperatureControlleA));
                }
            }
        }

        public float TemperatureReelle
        {
            get => _temperatureReelle;
            set
            {
                if (_temperatureReelle != value)
                {
                    _temperatureReelle = value;
                    OnPropertyChanged(nameof(TemperatureReelle));
                }
            }
        }

        public float LuminositeControlleDe
        {
            get => _luminositeControlleDe;
            set
            {
                if (_luminositeControlleDe != value)
                {
                    _luminositeControlleDe = value;
                    OnPropertyChanged(nameof(LuminositeControlleDe));
                }
            }
        }

        public float LuminositeControlleA
        {
            get => _luminositeControlleA;
            set
            {
                if (_luminositeControlleA != value)
                {
                    _luminositeControlleA = value;
                    OnPropertyChanged(nameof(LuminositeControlleA));
                }
            }
        }

        public float LuminositeReelle
        {
            get => _luminositeReelle;
            set
            {
                if (_luminositeReelle != value)
                {
                    _luminositeReelle = value;
                    OnPropertyChanged(nameof(LuminositeReelle));
                }
            }
        }

        public float HumiditeControlleDe
        {
            get => _humiditeControlleDe;
            set
            {
                if (_humiditeControlleDe != value)
                {
                    _humiditeControlleDe = value;
                    OnPropertyChanged(nameof(HumiditeControlleDe));
                }
            }
        }

        public float HumiditeControlleA
        {
            get => _humiditeControlleA;
            set
            {
                if (_humiditeControlleA != value)
                {
                    _humiditeControlleA = value;
                    OnPropertyChanged(nameof(HumiditeControlleA));
                }
            }
        }

        public float HumiditeReelle
        {
            get => _humiditeReelle;
            set
            {
                if (_humiditeReelle != value)
                {
                    _humiditeReelle = value;
                    OnPropertyChanged(nameof(HumiditeReelle));
                }
            }
        }

     
    }
}
