using NeuralNetwork_Connect4.Models;

namespace NeuralNetwork_Connect4.ViewModels
{
    public class EvolutionProgressViewModel : BindableBase
    {
        private readonly EvolutionProgress _evolutionProgress;
        public EvolutionProgressViewModel(EvolutionProgress evolutionProgress)
        {
            _evolutionProgress = evolutionProgress;
        }

        public uint Generation => _evolutionProgress.Generation;
        public Candidate GoldPlayer => _evolutionProgress.GoldPlayer;
        public Candidate SilverPlayer => _evolutionProgress.SilverPlayer;
    }
}
