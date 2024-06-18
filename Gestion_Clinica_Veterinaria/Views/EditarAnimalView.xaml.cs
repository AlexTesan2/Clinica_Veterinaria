using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_Clinica_Veterinaria.Models;

namespace Gestion_Clinica_Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para EditarAnimalView.xaml
    /// </summary>
    public partial class EditarAnimalView : UserControl
    {
        private AnimalModel _animal;

        public EditarAnimalView(AnimalModel animal)
        {
            InitializeComponent();
            _animal = animal;
            DataContext = _animal;
        }
    }
}
