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

namespace Aula_Numero_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<string> _Lista = null;
        const int Maxelementos = 4;

        public MainWindow()
        {
            InitializeComponent();

            InicializaListaSegundaManeira();
        }

        private void InicializaListaSegundaManeira()
        {
            try 
            { 
            for(int i =0; i<Maxelementos; i++)
                {
                    ListItems.Items.Add("Texto do elemento " + (i + 1).ToString());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BTSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult Resposta;

            try
            {
                Resposta = MessageBox.Show("Tem a certeza?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Resposta == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

     private void ListBoxDuploClique(object sender, RoutedEventArgs e)
        {
            JanelaSecundaria Segunda = new JanelaSecundaria(ListItems);
            Segunda.ShowDialog();  
        }
    }
}
