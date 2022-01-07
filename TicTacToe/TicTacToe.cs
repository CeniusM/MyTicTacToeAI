namespace MyTicTacToe
{
    class TicTacToe // mostly used for AI's
    {
        public int[] board { get; private set; } = new int[9];
        public int playerTurn { get; private set; } = 1;
        public int winner { get; private set; } = 0;
        public bool running { get; private set; } = true;
        private int moveAmout = 0;
        public bool MakeMove(int move) // the return value is just if i wanna use it to punish ais for making an ilegal move
        {
            if (board[move] == 0 && running)
            {
                board[move] = playerTurn;
                moveAmout++;

                if (IsGameOver())
                {
                    winner = playerTurn;
                    running = false;
                    return true;
                }
                else
                {
                    SwitchPlayer();
                }
                if (moveAmout == 9)
                {
                    playerTurn = 0;
                    return true;
                }
            }
            return false;
        }

        private bool IsGameOver()
        {
            for (int i = 0; i < 3; i++)
            {
                // lodret
                if (board[0 + (i * 3)] != 0)
                    if (board[0 + (i * 3)] == board[1 + (i * 3)] && board[1 + (i * 3)] == board[2 + (i * 3)])
                        return true;

                // vandret
                if (board[0 + i] != 0)
                    if (board[0 + i] == board[3 + i] && board[3 + i] == board[6 + i])
                        return true;
            }

            // diagonalerne
            if (board[board[0]] != 0)
                if (board[0] == board[4] && board[0] == board[8])
                    return true;
            if (board[2] != 0)
                if (board[2] == board[4] && board[2] == board[6])
                    return true;

            return false;
        }


        private void SwitchPlayer()
        {
            if (playerTurn == 1) playerTurn = 2;
            else playerTurn = 1;
        }
    }
}