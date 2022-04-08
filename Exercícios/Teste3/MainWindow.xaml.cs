using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Teste3
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.DefaultExt = "csv";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName.ToLower().EndsWith(".csv"))
                    using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            string[] subs = line.Split(';');
                            txtNum.Text = subs[0];
                            txtNome.Text = subs[1];
                            Data.SelectedDate = DateTime.Parse(subs[2]);
                        }
                    }
                else
                    System.Windows.MessageBox.Show("Extensão do ficheiro inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuWrite_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.CheckPathExists = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                if (saveFileDialog.FileName.ToLower().EndsWith(".csv"))
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                    {
                        writer.WriteLine(txtNum.Text + ";" + txtNome.Text + ";" + Data.SelectedDate.Value.ToShortDateString());
                    }
                else
                    MessageBox.Show("Extensão do ficheiro inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Pretende sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question))
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