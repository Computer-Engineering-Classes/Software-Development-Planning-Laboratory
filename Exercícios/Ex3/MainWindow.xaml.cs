using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_Ex3
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

        private void MenuRead_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("./dados.csv"))
            {
                using (var sr = new StreamReader("./dados.csv"))
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] subs = line.Split(';');
                        txtNum.Text = subs[0];
                        txtNome.Text = subs[1];
                        Data.SelectedDate = DateTime.Parse(subs[2]);
                    }
                }
            }
            else 
                MessageBox.Show("O ficheiro de dados não foi encontrado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MenuWrite_Click(object sender, RoutedEventArgs e)
        {
            using (var sr = new StreamWriter("./dados.csv"))
            {
                sr.WriteLine(txtNum.Text + ";" + txtNome.Text + ";" + Data.SelectedDate.Value.ToShortDateString());
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            switch(MessageBox.Show("Pretende sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
