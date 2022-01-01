namespace CS_TicTacToe
{
    class TicTacToe
    {
        public int[,] Board { get; private set; }
        public int playerTurn { get; private set; }
        public bool gameRunning { get; private set; }
        public int winner { get; private set; }
        private int moveAmout = 0;
        public TicTacToe()
        {
            Board = new int[3, 3];
            playerTurn = 1;
            gameRunning = true;
            winner = 0;
        }

        public void MakeMove(int i, int j)
        {
            if (!gameRunning) return;

            if (Board[i, j] == 0)
            {
                Board[i, j] = playerTurn;
                moveAmout++;

                GameoverCheck(i, j);

                if (!gameRunning) return;

                ChangePlayer();
            }

            //checks if after the ninth move is true and gameovercheck is false, the n stop the game with no winner
            if (moveAmout == 9)
                gameRunning = false;
        }

        private void GameoverCheck(int i, int j) // shit code, needs improvment
        {
            // Code
            bool vanret = false;
            bool lodret = false;
            bool diagonal = false;
            int vanretNum = 0;
            int lodretNum = 0;
            int diagonal1 = 0;
            int diagonal2 = 0;

            for (int k = 0; k < 3; k++)
            {
                // vandret
                if (Board[i, k] == playerTurn)
                    vanretNum++;

                // lodret
                if (Board[k, j] == playerTurn)
                    lodretNum++;

                if (Board[k, k] == playerTurn)
                    diagonal1++;
            }
            if (Board[0, 2] == playerTurn)
                diagonal2++;
            if (Board[1, 1] == playerTurn)
                diagonal2++;
            if (Board[2, 0] == playerTurn)
                diagonal2++;

            if (vanretNum == 3)
                vanret = true;
            if (lodretNum == 3)
                lodret = true;
            if (diagonal1 == 3)
                diagonal = true;
            if (diagonal2 == 3)
                diagonal = true;

            if (vanret || lodret || diagonal)
            {
                gameRunning = false;
                winner = playerTurn;
            }
        }

        private void ChangePlayer()
        {
            if (playerTurn == 1) playerTurn = 2;
            else playerTurn = 1;
        }

        public static int Get1DField(int x, int y)
        {
            int field = x;
            if (y != 0)
                field += y * 3;

            return field;
        }

        public static int[] Get2DField(int pos) // returns an x and y value
        {
            return new int[1];
        }
    }
}