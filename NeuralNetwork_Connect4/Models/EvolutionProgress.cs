using System.Collections.Generic;

namespace NeuralNetwork_Connect4.Models
{
    public class EvolutionProgress
    {
        public uint Generation { get; }
 
        public EvolutionProgress(uint generation)
        {
            Generation = generation;
        }
    }

}
