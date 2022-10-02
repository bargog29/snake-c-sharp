using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class BSnake : Form
    {
        Random r;  // pentru bonusuri
        enum campuri
        {
            Gol,Snake,Bonus
        };
        // lista campuri din tabela(in tabela noastra de joc putem avea 3 tipuri de campuri):
        // 1. campuri goale , unde nu avem nimic
        // 2. campurile unde se afla sarpele
        // 3. campurile unde se afla bonusurile


        enum Directii
        {
            Sus,Jos,Stanga,Dreapta
        }; 
        // lista directii : 4 directii(sus , jos , stanga , dreapta)
 

        struct Coordonate
        {
            // coordonatele caracterului
            public int x;
           public int y;
        }; 


        campuri[,] tabela; //matrice de tip campuri , prin care putem accesa campurile din tabela de joc

        Coordonate[] snakeXY;  // vectori de tip coordonate pentru a memora coordonatele caracterului

        int snakeLungime; // lungimea caracterului pe care o vom modifica la fiecare moment
        Directii d; // o variabila de tip directii prin care putem accesa directiile 

        Graphics g; // variabila care ne va ajuta sa "pictam" totul in tabela

        public BSnake()
        {
            //initializam variabilele
            InitializeComponent();
            tabela = new campuri[18, 18];
            snakeXY = new Coordonate[500];
            r = new Random();
        }

        private void BSnake_Load(object sender, EventArgs e)
        {
            TabelaDeJoc.Image = new Bitmap(630, 630); // in acest "Bitmap" creat vom "picta" imaginile
            g = Graphics.FromImage(TabelaDeJoc.Image);
            g.Clear(Color.White);

            for (int i = 0; i <= 17; i++)
            {
                //afisam zidurile de sus si de jos
                g.DrawImage(imglist.Images[0], i * 35, 0);
                g.DrawImage(imglist.Images[0], i * 35, 595);
            }

            for (int i = 0; i <= 18; i++)
            {
                //afisam zidurile din stanga si dreapta
                g.DrawImage(imglist.Images[0], 0, i * 35);
                g.DrawImage(imglist.Images[0], 595, i * 35);
            }


            // afisam sarpele la coordonatele initiale
            snakeXY[0].x = 5;
            snakeXY[0].y = 15; //coordonatele capului

            snakeXY[1].x = 5;
            snakeXY[1].y = 16;  // coordonatele primei parti din corp



            g.DrawImage(imglist1.Images[4], 5 * 35, 15 * 35);
            g.DrawImage(imglist1.Images[5], 5 * 35, 16 * 35); //prima parte a corpului pictata pe mapa


            tabela[5, 15] = campuri.Snake;
            tabela[5, 16] = campuri.Snake;

            d = Directii.Sus;  //pornim initial in sus
            snakeLungime = 2;  //sarpele are initial doar capul si o singura parte din corp


            Bonus();
        }
        //"pictam" bonusurile pe mapa 
        private void Bonus()
        {
            int x, y;

            do
            {
                x = r.Next(1, 17);
                y = r.Next(1, 17);
                //coordonatele random din mapa
            } while (tabela[x, y] != campuri.Gol); // verificam daca bonusul pica pe un camp liber

            tabela[x, y] = campuri.Bonus;
            g.DrawImage(imglist1.Images[0], x * 35, y * 35);
        }

        // setam directiile pe care se va misca sarpele
        private void BSnake_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:               
                    timer.Enabled = true;
                    d = Directii.Sus;
                    break;                          
                case Keys.Down:
                    timer.Enabled = true;
                    d = Directii.Jos;
                    break;
                case Keys.Right:
                    timer.Enabled = true;
                    d = Directii.Dreapta;
                    break;
                case Keys.Left:
                    timer.Enabled = true;
                    d = Directii.Stanga;
                    break;
            }
        }
        private void Sfarsitul_Jocului()
        {
            timer.Enabled = false;
            MessageBox.Show("Joc terminat - Snake - scor:" + snakeLungime);
            ActiveForm.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //stergem coada caracterului
            g.FillRectangle(Brushes.White, snakeXY[snakeLungime - 1].x * 35, snakeXY[snakeLungime - 1].y * 35, 35, 35);
            tabela[snakeXY[snakeLungime - 1].x, snakeXY[snakeLungime - 1].y] = campuri.Gol;

            //misca caracterul pe pozitia din urma
            for (int i = snakeLungime; i >= 1; i--)
            {
                snakeXY[i].x = snakeXY[i - 1].x;
                snakeXY[i].y = snakeXY[i - 1].y;
            }
            g.DrawImage(imglist1.Images[5], snakeXY[0].x * 35, snakeXY[0].y * 35);


            //schimbam directia 
            switch (d)
            {
                case Directii.Sus:
                    snakeXY[0].y = snakeXY[0].y - 1;
                    break;
                case Directii.Jos:
                    snakeXY[0].y = snakeXY[0].y + 1;
                    break;
                case Directii.Stanga:
                    snakeXY[0].x = snakeXY[0].x - 1;
                    break;
                case Directii.Dreapta:
                    snakeXY[0].x = snakeXY[0].x + 1;
                    break;
            }

            // verificam daca lovim zidul
            if (snakeXY[0].x < 1 || snakeXY[0].x >= 17 || snakeXY[0].y < 1 || snakeXY[0].y >= 17)
            {
                g.DrawImage(imglist1.Images[6], snakeXY[0].x * 35, snakeXY[0].y * 35);
                tabela[snakeXY[0].x, snakeXY[0].y] = campuri.Snake;
                TabelaDeJoc.Refresh();
                Sfarsitul_Jocului();
                return;
            }

            // verificam daca ne lovim de corpul caracterului
            if (tabela[snakeXY[0].x, snakeXY[0].y] == campuri.Snake)
            {
                g.DrawImage(imglist1.Images[6], snakeXY[0].x * 35, snakeXY[0].y * 35);
                tabela[snakeXY[0].x, snakeXY[0].y] = campuri.Snake;
                TabelaDeJoc.Refresh();
                Sfarsitul_Jocului();
                return;
            }


            // verificam daca mancam bonusul
            if (tabela[snakeXY[0].x, snakeXY[0].y] == campuri.Bonus)
            {
                Console.Beep(2000, 50);
                g.DrawImage(imglist1.Images[5], snakeXY[snakeLungime].x * 35, snakeXY[snakeLungime].y * 35);
                tabela[snakeXY[snakeLungime].x, snakeXY[snakeLungime].y] = campuri.Snake;
                snakeLungime++;

                if (snakeLungime < 289)
                    Bonus();

               Text = "Scor - " + snakeLungime;
            }


            // desenam capul caracterului
            g.DrawImage(imglist1.Images[4], snakeXY[0].x * 35, snakeXY[0].y * 35);
            tabela[snakeXY[0].x, snakeXY[0].y] = campuri.Snake;

            TabelaDeJoc.Refresh();
        }

    }
}
