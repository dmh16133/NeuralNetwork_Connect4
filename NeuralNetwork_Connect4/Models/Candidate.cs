namespace NeuralNetwork_Connect4.Models
{
    public class Candidate
    {
        private NeuralNetwork _neuralNetwork;
        
        public Candidate()
        {
            _neuralNetwork = new NeuralNetwork();
            Score = 0;
        }

        public Candidate(Candidate other)
        {
            _neuralNetwork = other._neuralNetwork;
            Score = 0;
        }
        
        public int GetMove(GameBoard gameBoard)
        {
            return 0;
        }

        public double Score { get; set; }
    }
}