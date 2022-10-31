namespace NeuralNetwork_Connect4.Models
{
    public class EvolutionProgress
    {
        public bool IsEndConditionReached { get; }
        public uint Generation { get; }

        public EvolutionProgress(uint generation)
        {
            Generation = generation;
            IsEndConditionReached = generation > 5;
        }
    }
}
