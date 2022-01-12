using winForm; // tictactoe GUI

namespace MyGame
{
    class GUI
    {

        private Form1 _Form;
        private Bitmap _Bitmap;
        private Graphics graphicsObj;
        private Pen _Pen;
        System.Drawing.SolidBrush _Brush;
        public GUI(Form1 _Form)
        {
            this._Form = _Form;
            _Bitmap = new Bitmap(_Form.ClientSize.Height, _Form.ClientSize.Width);
            graphicsObj = Graphics.FromImage(_Bitmap);
            _Pen = new Pen(Color.Black);
            _Brush = new System.Drawing.SolidBrush(Color.Black);
        }

        public void Print()
        {
            _Form.graphicsObj.DrawImage(_Bitmap, 0, 0);
        }

        public void Reset()
        {
            _Bitmap = new Bitmap(_Bitmap.Width, _Bitmap.Height);
        }
        public void Resetv2()
        {
            _Brush.Color = Color.White;
            graphicsObj.FillRectangle(_Brush, 0, 0, _Bitmap.Width, _Bitmap.Height);
            // _Bitmap = new Bitmap(_Bitmap.Width, _Bitmap.Height, graphicsObj);
            // graphicsObj = Graphics.FromImage(_Bitmap);
        }

        public void DrawLine(int x1, int y1, int x2, int y2, Color color, int width)
        {
            _Pen.Color = color;
            _Pen.Width = width;
            graphicsObj.DrawLine(_Pen, x1, y1, x2, y2);
        }

        public void DrawLine(Point one, Point two, Color color, int width)
        {
            _Pen.Color = color;
            _Pen.Width = width;
            graphicsObj.DrawLine(_Pen, one.X, one.Y, two.X, two.Y);
        }

        public void DrawNought(int x1, int y1, int r, int width, Color color)
        {
            _Pen.Color = color;
            _Pen.Width = width;
            graphicsObj.DrawEllipse(_Pen, x1, y1, r, r);
        }

        public void DrawCrosse(int x1, int y1, int size, int width, Color color)
        {
            _Pen.Color = color;
            _Pen.Width = width;
            graphicsObj.DrawLine(_Pen, x1 - size / 2, y1 - size / 2, x1 + size / 2, y1 + size / 2);
            graphicsObj.DrawLine(_Pen, x1 + size / 2, y1 - size / 2, x1 - size / 2, y1 + size / 2);
        }

        public void DrawBall(Point one, int radius, Color color)
        {
            _Brush.Color = color;
            graphicsObj.FillEllipse(_Brush, one.X, one.Y, radius, radius);
        }

        public void DrawBall(int x, int y, int radius, Color color)
        {
            _Brush.Color = color;
            graphicsObj.FillEllipse(_Brush, x, y, radius, radius);
        }
    }
}