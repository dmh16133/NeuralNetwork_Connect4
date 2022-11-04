using System;
using System.Threading.Tasks;
using NeuralNetwork_Connect4.ViewModels;
using System.Windows;
using NeuralNetwork_Connect4.Models;
using Environment = NeuralNetwork_Connect4.Models.Environment;

namespace NeuralNetwork_Connect4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _randomNumberGenerator = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Initialized(object sender,
                                              System.EventArgs e)
        {
            var progress = new Progress<EvolutionProgress>(evolutionProgress =>
            {
                DataContext = new EvolutionProgressViewModel(evolutionProgress);
            });
            
            await Task.Run(() => DoProcessing(progress));
        }
        
        private void DoProcessing(IProgress<EvolutionProgress> progress)
        {
            foreach (var evolutionProgress in Environment.GetEvolutionProgress(_randomNumberGenerator))
            {
                progress.Report(evolutionProgress);                
            }
        }
    }
}
