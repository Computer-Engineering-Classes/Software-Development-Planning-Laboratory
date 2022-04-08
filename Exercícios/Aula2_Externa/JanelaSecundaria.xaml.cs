using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aula_Numero_2
{
    /// <summary>
    /// Interaction logic for JanelaSecundária.xaml
    /// </summary>
    public partial class JanelaSecundaria : Window
    {
        ListBox _ListaItems = null;

        public JanelaSecundaria(ListBox ListaItems)
        {
            InitializeComponent();

            _ListaItems = ListaItems;
            TBDescricao.Text = (string)_ListaItems.SelectedItem;
        }

        private void BTCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTAlterar_Click(object sender, RoutedEventArgs e)
        {
            _ListaItems.Items[_ListaItems.SelectedIndex] = TBDescricao.Text;
            this.Close();
        }
    }
}
