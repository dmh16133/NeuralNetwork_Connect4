using System;
using System.Linq;

namespace NeuralNetwork_Connect4.Models
{
    public class Candidate
    {
        public NeuralNetwork NeuralNetwork { get; }
        
        public Candidate(int name, Random randomNumberGenerator)
        {
            Name = name;
            NeuralNetwork = new NeuralNetwork(randomNumberGenerator);
            Score = 0;
        }

        public Candidate(Candidate other)
        {
            Name = other.Name;
            NeuralNetwork = other.NeuralNetwork;
            Score = 0;
        }

        public Candidate(int name,
                         Candidate other)
        {
            Name = name;
            NeuralNetwork = other.NeuralNetwork;
            Score = 0;
        }

        public int GetMove(GameBoard gameBoard,
                           bool IsRedPlayer)
        {
            for (int iRow = 0;
                     iRow < GameBoard.NumberOfRows;
                     iRow++)
            {
                for (int iColumn = 0;
                         iColumn < GameBoard.NumberOfColumns;
                         iColumn++)
                {
                    switch (gameBoard.Grid[iRow,
                                           iColumn])
                    {
                        case TokenType.Black:
                            NeuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(1);
                            break;
                        
                        case TokenType.Empty:
                            NeuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(0);
                            break;
                            
                        case TokenType.Red:
                            NeuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(-1);
                            break;
                    }
                }
            }
            
            NeuralNetwork.Recalculate();
            var mostActivatedNode = NeuralNetwork.OutputNodes
                .OrderBy(x => x.ActivationValue)
                .Last();
                
            return NeuralNetwork.OutputNodes.IndexOf(mostActivatedNode);
        }

        public int Name { get; }
        public double Score { get; set; }
    }
}