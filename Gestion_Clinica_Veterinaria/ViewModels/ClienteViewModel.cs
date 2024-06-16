using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Input;
using Gestion_Clinica_Veterinaria.ViewModels;

namespace Gestion_Clinica_Veterinaria.ViewModels
{
    public class ClienteViewModel : ViewModelBase
    {
        //Campos
        private ViewModelBase _currentChildView;

        //Propiedades
        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        //Comandos
        public ICommand ConsultarComand { get; }
        public ICommand CrearComand { get; }

        public ClienteViewModel()
        {
            //inicializar comandos
            ConsultarComand = new ViewModelCommand(ExecuteConsultarComand);
            CrearComand = new ViewModelCommand(ExecuteCrearComand);


            //vista por defecto
            ExecuteConsultarComand(null);
        }

        private void ExecuteConsultarComand(object obj)
        {
            CurrentChildView = new ConsultarClienteViewModel();
        }
        private void ExecuteCrearComand(object obj)
        {
            CurrentChildView = new CrearClienteViewModel();
        }
    }
}
