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
        private string _title;
        private IconChar _icon;


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
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }


        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Comandos
        public ICommand ShowHomeViewComand { get; }
        public ICommand ShowCustomerViewComand { get; }
        public ICommand ShowCarViewComand { get; }
        public ICommand ShowClienteViewComand { get; }

        public MainWindowModel()
        {
            //inicializar comandos
            ShowHomeViewComand = new ViewModelCommand(ExecuteShowHomeViewComand);
            ShowCustomerViewComand = new ViewModelCommand(ExecuteShowCustomerViewComand);
            ShowCarViewComand = new ViewModelCommand(ExecuteShowCarViewComand);
            ShowClienteViewComand = new ViewModelCommand(ExecuteShowClienteViewComand);


            //vista por defecto
            ExecuteShowHomeViewComand(null);
        }

        private void ExecuteShowHomeViewComand(object obj)
        {
            CurretChildView = new HomeViewModel();
            Title = "Home";
            Icon = IconChar.Home;
        }
        private void ExecuteShowCustomerViewComand(object obj)
        {
            CurretChildView = new CustomerViewModel();
            Title = "Customers";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowCarViewComand(object obj)
        {
            CurretChildView = new CarViewModel();
            Title = "Car";
            Icon = IconChar.CarAlt;
        }
        private void ExecuteShowClienteViewComand(object obj)
        {
            CurretChildView = new ClienteViewModel();
            Title = "Cliente";
            Icon = IconChar.User;
        }
    }
}
