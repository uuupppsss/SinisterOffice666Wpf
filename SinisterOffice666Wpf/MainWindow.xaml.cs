﻿using System.Text;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SinisterOffice666Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        HttpClient httpClient=new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("http://localhost:5148/api/");
            DataContext=this;
        }


    }
}