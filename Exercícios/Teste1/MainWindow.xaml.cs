using System;
using System.Windows;
using System.Windows.Media;

namespace Ex2
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

        private void ButtonSoma_Click(object sender, RoutedEventArgs e)
        {
            bool v1 = false, v2 = false;
            if ((v1 = Int32.TryParse(BoxValor1.Text, out int valor1)) && (v2 = Int32.TryParse(BoxValor2.Text, out int valor2)))
            {
                BoxValor1.Background = Brushes.White;
                BoxValor2.Background = Brushes.White;
                int soma = valor1 + valor2;
                Resultado.Text = $"{soma}";
            }
            else if (!v1 && !v2)
            {
                BoxValor1.Background = Brushes.Pink;
                BoxValor2.Background = Brushes.Pink;
                MessageBox.Show("Campos mal preenchidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (!v2)
            {
                BoxValor2.Background = Brushes.Pink;
                BoxValor1.Background = Brushes.White;
                MessageBox.Show("Campo \"Valor 2\" mal preenchido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BoxValor1.Background = Brushes.Pink;
                BoxValor2.Background = Brushes.White;
                MessageBox.Show("Campo \"Valor 1\" mal preenchido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
