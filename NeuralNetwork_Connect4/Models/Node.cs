using System;

namespace NeuralNetwork_Connect4.Models
{
    public class Node
    {
        private double _internalSum = 0;
        public Node(int nodeIndex, double bias)
        {
            NodeIndex = nodeIndex;
            Bias = bias;
            AddWeightedValue(0);
        }

        public void AddWeightedValue(double value)
        {
            _internalSum += value;
            ActivationValue = 1.0 / (1 + Math.Pow(Math.E,
                                                 -(_internalSum + Bias)));
        }
        
        public int NodeIndex { get; }
        public double Bias { get; }
        public double ActivationValue { get; private set; } 
    }
}