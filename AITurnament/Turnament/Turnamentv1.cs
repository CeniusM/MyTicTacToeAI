using CS_TicTacToe;
using CS_TicTacToeAI;

namespace TTT_Turnament
{
    class Turnamentv1
    {
        private int _iNodes;
        private int _oNodes;
        private int _hNodes;
        public Turnamentv1(int iNodes, int oNodes, int hNodes)
        {
            _iNodes = iNodes;
            _oNodes = oNodes;
            _hNodes = hNodes;
        }

        public void Start()
        {

        }

        private TicTacToeAIv1 CreatedRandomAI()
        {
            var myRandomAI = new TicTacToeAIv1(_iNodes, _oNodes, _hNodes);
            return myRandomAI;
        }
    }
}