namespace NeuralNetwork_Connect4.Models
{
	public class GameBoard
	{
		public static readonly int Rows = 6;
		public static readonly int Columns = 7;


		public TokenType[,] Grid { get; set; }

		public GameBoard()
		{
			Grid = new TokenType[Rows, Columns];
			for (int row = 0; row < Rows; row++)
			{
				for (int column = 0; column < Columns; column++)
				{
					Grid[row, column] = TokenType.Empty;
				}
			}
		}

		public void Add(int column, TokenType token)
		{
			// just verifying that the column has space
			if (!CanAdd(column))
				return;

			int currentRow = 0;
			while (currentRow < Rows - 1 &&
				Grid[currentRow + 1, column] == TokenType.Empty)
			{
				//we only increase the currentRow if the slot below is empty and in bounds
				currentRow++;
			}

			//place the token in the specified column and gravity-decided row
			Grid[currentRow, column] = token;
		}

		public bool IsGridFull()
		{
			for (int column = 0; column < Columns; column++)
			{
				if (CanAdd(column))
					return false;
			}

			return true;
		}

		public bool CanAdd(int column)
		{
			return (Grid[0, column] == TokenType.Empty);
		}

		public bool HasWon(TokenType type)
		{
			//brute force on the whole board instead of checking from the most-recent play
			//b/c simpler to code
			for (int row = 0; row < Rows; row++)
			{
				for (int column = 0; column < Columns; column++)
				{
					if (HasWinOnVertical(row, column, type))
						return true;
					if (HasWinOnHorizontal(row, column, type))
						return true;
					if (HasWinDiagonallyDown(row, column, type))
						return true;
					if (HasWinDiagonallyUp(row, column, type))
						return true;
				}
			}

			return false;
		}

		private bool HasWinOnHorizontal(int row, int column, TokenType type)
		{
			// short circuit if there aren't even four more spots before leaving the grid
			if (column + 3 >= Columns)
				return false;

			//short circuit once we have a negative outcome
			for (int distance = 0; distance < 4; distance++)
			{
				if (Grid[row, column + distance] != type)
					return false;
			}

			return true;
		}

		private bool HasWinOnVertical(int row, int column, TokenType type)
		{
			// short circuit if there aren't even four more spots before leaving the grid
			if (row + 3 >= Rows)
				return false;

			//short circuit once we have a negative outcome
			for (int distance = 0; distance < 4; distance++)
			{
				if (Grid[row + distance, column] != type)
					return false;
			}

			return true;
		}

		private bool HasWinDiagonallyDown(int row, int column, TokenType type)
		{
			// short circuit if there aren't even four more spots before leaving the grid
			if ((row + 3 >= Rows) || (column + 3 >= Columns))
				return false;

			//short circuit once we have a negative outcome
			for (int distance = 0; distance < 4; distance++)
			{
				if (Grid[row + distance, column + distance] != type)
					return false;
			}

			return true;
		}

		private bool HasWinDiagonallyUp(int row, int column, TokenType type)
		{
			// short circuit if there aren't even four more spots before leaving the grid
			if ((row - 3 < 0) || (column + 3 >= Columns))
				return false;

			//short circuit once we have a negative outcome
			for (int distance = 0; distance < 4; distance++)
			{
				if (Grid[row - distance, column + distance] != type)
					return false;
			}

			return true;
		}

		public bool CanContinue()
		{
			return !HasWon(TokenType.Red) &&
				   !HasWon(TokenType.Black) &&
				   !IsGridFull();
		}
	}
}
