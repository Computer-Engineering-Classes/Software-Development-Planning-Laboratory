﻿using System;
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

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcao;
            opcao = MessageBox.Show("Tem a certeza?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcao == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = ItemsList.SelectedItem as ListBoxItem;
            JanelaSecundaria janela = new JanelaSecundaria();
            janela.Texto = item.Content.ToString();
            if(janela.ShowDialog() == true)
            {
                item.Content = janela.Texto;
            }
        }
    }
}
