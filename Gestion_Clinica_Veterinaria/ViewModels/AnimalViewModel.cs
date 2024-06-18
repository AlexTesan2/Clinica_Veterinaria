using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gestion_Clinica_Veterinaria.ViewModels
{
    public class AnimalViewModel : ViewModelBase
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

        public AnimalViewModel()
        {
            //inicializar comandos
            ConsultarComand = new ViewModelCommand(ExecuteConsultarComand);
            CrearComand = new ViewModelCommand(ExecuteCrearComand);


            //vista por defecto
            ExecuteConsultarComand(null);
        }

        private void ExecuteConsultarComand(object obj)
        {
            CurrentChildView = new ConsultarAnimalViewModel();
        }
        private void ExecuteCrearComand(object obj)
        {
            CurrentChildView = new CrearAnimalViewModel();
        }
    }
}
