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

using NgScaffold.Model;

namespace NgScaffold.UI
{
    /// <summary>
    /// Interaction logic for SelectModelWindow.xaml
    /// </summary>
    public partial class ListarEntidadesView : Window
    {
        public ListarEntidadesView(ListarEntidadesViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void cboListaDeContextos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trvEntidades.ItemsSource = ((ListarEntidadesViewModel)DataContext).ListaDeEntidades;
        }

        private void btnGerar_Click(object sender, RoutedEventArgs e)
        {
            foreach (TipoDoModelo item in trvEntidades.Items)
            {
                if (item.IsChecked)
                    ((ListarEntidadesViewModel)DataContext).ListaDeEntidadesSelecionadas.Add(item);
            }

            this.DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
