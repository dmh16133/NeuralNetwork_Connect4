using System;
using System.Linq;

namespace NeuralNetwork_Connect4.Models
{
    public class Candidate
    {
        private NeuralNetwork _neuralNetwork;
        
        public Candidate(int name, Random randomNumberGenerator)
        {
            Name = name;
            _neuralNetwork = new NeuralNetwork(randomNumberGenerator);
            Score = 0;
        }

        public Candidate(Candidate other)
        {
            Name = other.Name;
            _neuralNetwork = other._neuralNetwork;
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
                            _neuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(1);
                            break;
                        
                        case TokenType.Empty:
                            _neuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(0);
                            break;
                            
                        case TokenType.Red:
                            _neuralNetwork.InputNodes[iRow * GameBoard.NumberOfColumns + iColumn]
                                .AddWeightedValue(-1);
                            break;
                    }
                }
            }
            
            _neuralNetwork.Recalculate();
            var mostActivatedNode = _neuralNetwork.OutputNodes
                .OrderBy(x => x.ActivationValue)
                .Last();
                
            return _neuralNetwork.OutputNodes.IndexOf(mostActivatedNode);
        }

        public int Name { get; }
        public double Score { get; set; }
    }
}