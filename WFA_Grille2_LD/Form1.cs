using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Grille2_LD
{
    public partial class frm_Main : Form
    {
        Grille maGrille1 = new Grille(10, 10, 800, 800, 100, 100);

        public frm_Main()
        {
            DoubleBuffered = true;
            InitializeComponent();
            maGrille1.Echequier();
        }

        private void frm_Main_Paint(object sender, PaintEventArgs e)
        {
            maGrille1.Paint(sender, e);
        }
    }
}
