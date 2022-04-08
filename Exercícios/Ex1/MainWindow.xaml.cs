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

namespace Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Aceitar_Click(object sender, RoutedEventArgs e)
        {
            bool infoOk = true; //assumo que não existe erro no formulário

            if (String.IsNullOrEmpty(boxDesignacao.Text))
            {
                infoOk = false;
                boxDesignacao.Background = Brushes.Pink;
            }
            else
            {
                boxDesignacao.Background = Brushes.White;
            }

            if (DataEvento.SelectedDate.HasValue && DataEvento.SelectedDate.Value.Date >= DateTime.Now.Date)
            {
                DataEvento.Background = Brushes.White;
            }
            else
            {
                infoOk = false;
                DataEvento.Background = Brushes.Pink;
            }

            if(Int32.TryParse(boxHoraInicio.Text, out int HoraInicio))
            {
                boxHoraInicio.Background = Brushes.White;
            }
            else
            {
                infoOk = false;
                boxHoraInicio.Background = Brushes.Pink;
            }

            if (Int32.TryParse(boxMinutoInicio.Text, out int MinutoInicio))
            {
                boxMinutoInicio.Background = Brushes.White;
            }
            else
            {
                infoOk = false;
                boxMinutoInicio.Background = Brushes.Pink;
            }

            if (Int32.TryParse(boxDuracao.Text, out int Duracao))
            {
                boxDuracao.Background = Brushes.White;
            }
            else
            {
                infoOk = false;
                boxDuracao.Background = Brushes.Pink;
            }

            if (!infoOk)
            {
                MessageBox.Show("Campos mal preenchidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string mensagem = $"Foi inserido o seguinte evento:";
                mensagem += "\n\"" + boxDesignacao.Text + "\n\"";
                mensagem += "a " + DataEvento.SelectedDate.Value.ToShortDateString();
                mensagem += "\ncom início às " + HoraInicio + ":" + MinutoInicio;
                HoraInicio += Duracao / 60;
                MinutoInicio += Duracao % 60;
                HoraInicio += MinutoInicio / 60;
                MinutoInicio += Duracao % 60;
                mensagem += "\ncom término às " + HoraInicio + ":" + MinutoInicio;
                MessageBox.Show(mensagem, "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
