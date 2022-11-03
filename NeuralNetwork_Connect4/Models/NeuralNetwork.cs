using System;
using System.Collections.Generic;

namespace NeuralNetwork_Connect4.Models
{
    public class NeuralNetwork
    {
        private const int NumberOfGameInputNodes = 42;
        private const int NumberOfPlayerModeNodes = 1;

        private const int TotalNumberOfInputNodes = NumberOfGameInputNodes
                                                    + NumberOfPlayerModeNodes;
        
        private const int NumberOfOutputNodes = 7;

        private List<Node> _inputNodes;
        private List<Weight> _inputWeights;
        private List<Node> _internalNodes;
        private List<Weight> _outputWeights;
        private List<Node> _outputNodes;
        
        private readonly Random _random = new Random(); 
        
        public NeuralNetwork()
        {
            _inputNodes = new List<Node>();
            _inputWeights = new List<Weight>();
            _internalNodes = new List<Node>();
            _outputWeights = new List<Weight>();
            _outputNodes = new List<Node>();
            
            CreateInputNodes();

            int numberOfInternalNodes = _random.Next(NumberOfOutputNodes, 
                                                      NumberOfGameInputNodes);

            CreateInputWeights(numberOfInternalNodes);
            CreateInternalNodes(numberOfInternalNodes);
            CreateOutputWeights(numberOfInternalNodes);
            CreateOutputNodes();

            Recalculate();
        }

        private void CreateInputNodes()
        {
            for (int iInputNode = 0;
                     iInputNode < TotalNumberOfInputNodes;
                     iInputNode++)
            {
                _inputNodes.Add(new Node(iInputNode, 0));
            }
        }

        private void CreateInputWeights(int numberOfInternalNodes)
        {
            for (int iInputNodeIndex = 0;
                     iInputNodeIndex < TotalNumberOfInputNodes;
                     iInputNodeIndex++)
            {
                for (int iInternalNode = 0;
                         iInternalNode < numberOfInternalNodes;
                         iInternalNode++)
                {
                    _inputWeights.Add(new Weight(iInputNodeIndex, 
                                                 iInternalNode, 
                                                 _random.NextDouble()));
                }
            }
        }

        private void CreateInternalNodes(int numberOfInternalNodes)
        {
            for (int iInternalNodeIndex = 0; 
                     iInternalNodeIndex < numberOfInternalNodes; 
                     iInternalNodeIndex++)
            {
                _internalNodes.Add(new Node(iInternalNodeIndex, 
                                            _random.NextDouble()));
            }
        }

        private void CreateOutputWeights(int numberOfInternalNodes)
        {
            for (int iInternalNodeIndex = 0;
                     iInternalNodeIndex < numberOfInternalNodes;
                     iInternalNodeIndex ++)
            {
                for (int iOutputNode = 0;
                         iOutputNode < NumberOfOutputNodes;
                         iOutputNode++)
                {
                    _outputWeights.Add(new Weight(iInternalNodeIndex, 
                                                  iOutputNode, 
                                                  _random.NextDouble()));
                }
            }
        }

        private void CreateOutputNodes()
        {
            for (int iOutputNodeIndex = 0; 
                     iOutputNodeIndex < NumberOfOutputNodes; 
                     iOutputNodeIndex++)
            {
                _outputNodes.Add(new Node(iOutputNodeIndex, 
                                          _random.NextDouble()));
            }
        }

        private void Recalculate()
        {
            foreach (var iInputWeight in _inputWeights)
            {
                _internalNodes[iInputWeight.EndNodeIndex]
                    .AddWeightedValue(_inputNodes[iInputWeight.StartNodeIndex].ActivationValue
                                      * iInputWeight.WeightValue);
            }

            foreach (var iOutputWeight in _outputWeights)
            {
                _outputNodes[iOutputWeight.EndNodeIndex]
                    .AddWeightedValue(_internalNodes[iOutputWeight.StartNodeIndex].ActivationValue
                                      *iOutputWeight.WeightValue);
            }
        }
    }
}