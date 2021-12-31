namespace winForm;

public partial class Form1 : Form
{
    public System.Drawing.Graphics graphicsObj;
    public Form1()
    {
        InitializeComponent();

        graphicsObj = this.CreateGraphics();
    }
}
