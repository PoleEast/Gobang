using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        private gamemanager gamemanager = new gamemanager();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = gamemanager.PiaceAPiece(e.X, e.Y);
            if (piece != null)
                this.Controls.Add(piece);
            if (gamemanager.whoiswinner == 'w') 
            {
                MessageBox.Show("Witch is win");
                System.Environment.Exit(0);
            }
            if (gamemanager.whoiswinner == 'b')
            {
                MessageBox.Show("Black is win");
                System.Environment.Exit(0);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(gamemanager.PutPiece(e.X, e.Y))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }
    }
}
