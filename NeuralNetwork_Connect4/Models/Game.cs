namespace NeuralNetwork_Connect4.Models
{
    public class Game
    {
        private const int WinScore = 100;
        private const int WinByDefault = 50;
        private const int Tie = 25;
            
        public Game(Candidate redPlayer,
                    Candidate bluePlayer)
        {
            GameBoard = new GameBoard();

            while (true)
            {
                if (ResolvePlayerMove(redPlayer, TokenType.Red, bluePlayer))
                    return;
                
                if (ResolvePlayerMove(bluePlayer, TokenType.Black, redPlayer))
                    return;

                if (GameBoard.IsGridFull())
                {
                    redPlayer.Score += Tie;
                    bluePlayer.Score += Tie;
                    return;
                }
            }
        }

        private bool ResolvePlayerMove(Candidate player,
                                       TokenType tokenType,
                                       Candidate otherPlayer)
        {
            var move = player.GetMove(GameBoard,
                                      tokenType == TokenType.Red);
            
            if (!GameBoard.CanAdd(move))
            {
                otherPlayer.Score += WinByDefault;
                return true;
            }
            
            GameBoard.Add(move, tokenType);
            if (GameBoard.HasWon(tokenType))
            {
                player.Score += WinScore;
                return true;
            }
            
            return false;
        }

        public GameBoard GameBoard { get; }
    }
}