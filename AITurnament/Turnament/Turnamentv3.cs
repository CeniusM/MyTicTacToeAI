// have a set of ai's that only plays as player 1, and another set of ai's that only plays player 2
// make hot fixes and make it all faster
// make it work plz ;,)

using MyTicTacToe;
using CS_TicTacToeAI;
using CS_MyConsole;
using winForm;

namespace TTT_Turnament
{
    class Turnamentv3
    {
        public List<TurnamentStats> stats;
        private int _playerAmount;
        private int _generationAmount;
        private List<TicTacToeAIv3> _winners;
        private List<TicTacToeAIv3> _players;
        public Turnamentv3(int playerAmount, int generationAmount)
        {
            stats = new List<TurnamentStats>();
            _playerAmount = playerAmount;
            _generationAmount = generationAmount;
            _winners = new List<TicTacToeAIv3>();
            _players = new List<TicTacToeAIv3>();
            for (int i = 0; i < _playerAmount; i++)
            {
                _players.Add(new TicTacToeAIv3());
            }
        }
        public void Start()
        {

        }
    }
}