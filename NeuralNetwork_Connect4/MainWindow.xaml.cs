using NeuralNetwork_Connect4.Models;
using NeuralNetwork_Connect4.ViewModels;
using System.Windows;

namespace NeuralNetwork_Connect4
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

        private async void Window_Initialized(object sender,
                                              System.EventArgs e)
        {
            await foreach (var evolutionProgress in Environment.GetEvolutionProgressAsync())
            {
                DataContext = new EvolutionProgressViewModel(evolutionProgress);
            }
        }
    }
}
