using System.Collections.Generic;

namespace NeuralNetwork_Connect4.Models
{
    public class EvolutionProgress
    {
        public uint Generation { get; }
        public Candidate GoldPlayer { get; }
        public Candidate SilverPlayer { get; }
        public GameBoard BestPlayersGameOne { get; }
        public GameBoard BestPlayersGameTwo { get; }
        
 
        public EvolutionProgress(uint generation,
                                 Candidate goldPlayer,
                                 Candidate silverPlayer,
                                 GameBoard bestPlayersGameOne,
                                 GameBoard bestPlayersGameTwo)
        {
            Generation = generation;
            GoldPlayer = goldPlayer;
            SilverPlayer = silverPlayer;
            
            BestPlayersGameOne = bestPlayersGameOne;
            BestPlayersGameTwo = bestPlayersGameTwo;
        }
    }
}

