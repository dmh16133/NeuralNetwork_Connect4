using System.Collections.Generic;

namespace NeuralNetwork_Connect4.Models
{
    public class EvolutionProgress
    {
        public uint Generation { get; }
        public GameBoard BestPlayersGameOne { get; }
        public GameBoard BestPlayersGameTwo { get; }
        
 
        public EvolutionProgress(uint generation,
                                 GameBoard bestPlayersGameOne,
                                 GameBoard bestPlayersGameTwo)
        {
            Generation = generation;
        }
    }

}
