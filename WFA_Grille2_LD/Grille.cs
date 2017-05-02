using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Grille2_LD
{
    class Grille
    {
        int[,] LignesCollones;
        float tailleCasesX, tailleCasesY;

        Point position;
        Size taille;
        
        int nbrCaseX, nbrCaseY;
        PointF[][] tPointsCaseX, tPointsCaseY;


        /// <summary>
        /// Créer une grille avec les valeurs données en paramètres
        /// </summary>
        /// <param name="posX">La position X du point d'ou sera déssiné la grille</param>
        /// <param name="posY">La position Y du point d'ou sera déssiné la grille</param>
        /// <param name="tailleWidth">La hauteur en pixel de la grille</param>
        /// <param name="tailleHeight">La largeur en pixel de la grille</param>
        /// <param name="nbrCaseX">Le nombre de case sur l'axe X</param>
        /// <param name="nbrCaseY">Le nombre de case sur l'axe Y</param>
        public Grille(int posX, int posY, int tailleWidth, int tailleHeight, int nbrCaseX, int nbrCaseY)
        {
            position.X = posX;
            position.Y = posY;
            taille.Width = tailleWidth;
            taille.Height = tailleHeight;
            this.LignesCollones = new int[nbrCaseX, nbrCaseY];
            this.tailleCasesX = taille.Width / (float)nbrCaseX;
            this.tailleCasesY = taille.Height / (float)nbrCaseY;
            this.nbrCaseX = nbrCaseX;
            this.nbrCaseY = nbrCaseY;
            this.tPointsCaseX = new PointF[nbrCaseX][];
            this.tPointsCaseY = new PointF[nbrCaseY][];

            for (int i = 0; i < nbrCaseX; i++)
            {
                this.tPointsCaseX[i] = new PointF[2];
                this.tPointsCaseX[i][0] = new PointF(position.X + i * tailleCasesX, position.Y);
                this.tPointsCaseX[i][1] = new PointF(position.X + i * tailleCasesX, position.Y + taille.Height);
            }

            for (int i = 0; i < nbrCaseY; i++)
            {
                this.tPointsCaseY[i] = new PointF[2];
                this.tPointsCaseY[i][0] = new PointF(position.X, position.Y + i * tailleCasesY);
                this.tPointsCaseY[i][1] = new PointF(position.X + taille.Width, position.Y + i * tailleCasesY);
            }
        }

        public void Echequier()
        {
            Random rdm = new Random();
            for (int i = 0; i < nbrCaseX; i++)
            {
                for (int y = 0; y < nbrCaseY; y++)
                {
                    if ((y+i) % 2 == 1)
                    {
                        LignesCollones[i, y] = 1;
                    }
                    
                }
            }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Rectangle table = new Rectangle(position, taille);
            e.Graphics.DrawRectangle(Pens.Black, table);

            for (int i = 0; i < nbrCaseX; i++)
            {
                e.Graphics.DrawLine(Pens.Black, tPointsCaseX[i][0], tPointsCaseX[i][1]);
                for (int y = 0; y < nbrCaseY; y++)
                {
                    e.Graphics.DrawLine(Pens.Black, tPointsCaseY[y][0], tPointsCaseY[y][1]);

                    if (LignesCollones[i,y] == 1)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, new Rectangle((int)tPointsCaseX[i][0].X, (int)tPointsCaseY[y][0].Y, (int)tailleCasesX, (int)tailleCasesY));
                    }
                }
            }
        }
    }
}
