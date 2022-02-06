//the values will go from -1 - 1, or -10 - 10, the heigher the num is the heiger the green rgb vill be, and the lower the red'er
using TicTacToeAI;
using FormGUI;
using winForm;

namespace AIGUI
{
    class NetworkPrinter
    {
        private Form1 _form;
        private GUI _GUI;
        public NetworkPrinter(Form1 form)
        {
            _form = form;
            _GUI = new GUI(form);
        }

        public void PrintBrain(AIBrain brain)
        {
            _GUI.Reset();

            int height = _form.Height / 9;
            int widht = _form.Width / 4;
            int radiusOfNode = 40;

            int[] layerPos = { widht / 2, widht + widht / 2, (widht << 1) + widht / 2, widht * 3 + widht / 2 };


            for (int i = 0; i < 9; i++) // make method
            {
                _GUI.DrawCircel(layerPos[0], ((height * i) + (height >> 1)) - radiusOfNode, radiusOfNode, Color.Gray);
            }

            for (int i = 0; i < 9; i++) // make method
            {
                _GUI.DrawCircel(layerPos[1], ((height * i) + (height >> 1)) - radiusOfNode, radiusOfNode, Color.Gray);
            }

            for (int i = 0; i < 9; i++) // make method
            {
                _GUI.DrawCircel(layerPos[2], ((height * i) + (height >> 1)) - radiusOfNode, radiusOfNode, Color.Gray);
            }

            for (int i = 0; i < 9; i++) // make method
            {
                _GUI.DrawCircel(layerPos[3], ((height * i) + (height >> 1)) - radiusOfNode, radiusOfNode, Color.Gray);
            }

            for (int i = 0; i < 9; i++) // make method
            {
                int nodePos = (height * i) + (height >> 1) - (radiusOfNode >> 1);
                for (int j = 0; j < 9; j++)
                {
                    _GUI.DrawLine(layerPos[0] + (radiusOfNode >> 1), nodePos, layerPos[1] + (radiusOfNode >> 1), ((height * j) + (height >> 1) - (radiusOfNode >> 1)), (radiusOfNode >> 4), GetColor(brain.w1[i, j], brain.range));
                }
            }

            for (int i = 0; i < 9; i++) // make method
            {
                int nodePos = (height * i) + (height >> 1) - (radiusOfNode >> 1);
                for (int j = 0; j < 9; j++)
                {
                    _GUI.DrawLine(layerPos[1] + (radiusOfNode >> 1), nodePos, layerPos[2] + (radiusOfNode >> 1), ((height * j) + (height >> 1) - (radiusOfNode >> 1)), (radiusOfNode >> 4), GetColor(brain.w2[i, j], brain.range));
                }
            }

            for (int i = 0; i < 9; i++) // make method
            {
                int nodePos = (height * i) + (height >> 1) - (radiusOfNode >> 1);
                for (int j = 0; j < 9; j++)
                {
                    _GUI.DrawLine(layerPos[2] + (radiusOfNode >> 1), nodePos, layerPos[3] + (radiusOfNode >> 1), ((height * j) + (height >> 1) - (radiusOfNode >> 1)), (radiusOfNode >> 4), GetColor(brain.w3[i, j], brain.range));
                }
            }

            _GUI.Print();
        }

        public Color GetColor(float value, float range)
        {
            int alpha = 0;
            int Green = 0;
            int Red = 0;
            int Blue = 0;

            if (value > 0)// if over 0
            {
                Green = (int)((float)254 / range * value);
                alpha = Green;
                // Blue = 254 - Green;
                // Red = 254 - Green;
            }
            else if (value < 0)
            {
                range *= -1;
                Red = (int)((float)254 / range * value);
                alpha = Red;
                // Blue = 254 - Red;
                // Green = 254 - Red;
            }

            if (Green > 254) Green = 254;
            if (Red > 254) Red = 254;
            if (alpha > 254) alpha = 254;

            return Color.FromArgb(alpha, Red, Green, Blue);
        }
    }
}