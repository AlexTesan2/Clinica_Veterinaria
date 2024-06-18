using FontAwesome.Sharp;
using Gestion_Clinica_Veterinaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gestion_Clinica_Veterinaria.ViewModels
{
    public class MainWindowModel : ViewModelBase
    {
        //Campos
        private ViewModelBase _curretChildView;

        //Propiedades
        public ViewModelBase CurretChildView
        {
            get => _curretChildView;
            set
            {
                _curretChildView = value;
                OnPropertyChanged(nameof(CurretChildView));
            }
        }

        //Comandos
        public ICommand ShowClienteViewComand { get; }
        public ICommand ShowAnimalViewComand { get; }
        public ICommand ShowConsultaViewComand { get; }

        public MainWindowModel()
        {
            //inicializar comandos
            ShowClienteViewComand = new ViewModelCommand(ExecuteShowClienteViewComand);
            ShowAnimalViewComand = new ViewModelCommand(ExecuteShowAnimalViewComand);
            ShowConsultaViewComand = new ViewModelCommand(ExecuteShowConsultaViewComand);

            //vista por defecto
            ExecuteShowClienteViewComand(null);
        }
        private void ExecuteShowClienteViewComand(object obj)
        {
            CurretChildView = new ClienteViewModel();
        }

        private void ExecuteShowAnimalViewComand(object obj)
        {
            CurretChildView = new AnimalViewModel();
        }
        private void ExecuteShowConsultaViewComand(object obj)
        {
            CurretChildView = new ConsultaViewModel();
        }
    }
}
