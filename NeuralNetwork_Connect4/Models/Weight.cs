namespace NeuralNetwork_Connect4.Models
{
    public class Weight
    {
        public Weight(int startNodeIndex, 
                      int endNodeIndex, 
                      double weight)
        {
            StartNodeIndex = startNodeIndex;
            EndNodeIndex = endNodeIndex;
            WeightValue = weight;
        }
        
        public int StartNodeIndex { get; }
        public int EndNodeIndex { get; }
        public double WeightValue { get; }
    }
}