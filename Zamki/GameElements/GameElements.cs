using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamki.GameElements
{
    [Serializable]
    abstract public class Stuff
    {
        [Serializable]
        public class BeautifulSquare : Stuff // Закрашиваемые площади (полы, например)
        {
            public int posX1;
            public int posY1;
            public int posX2;
            public int posY2;
            public System.Drawing.Image image;

            public BeautifulSquare()
            {
                posX1 = 0;
                posY1 = 0;
                posY2 = 0;
                posX2 = 0;
                image = Zamki.Properties.Resources.invisible;
            }

            public BeautifulSquare(int posX1, int posY1, int posX2, int posY2, System.Drawing.Image image) // Конструктор
            {
                this.posX1 = posX1;
                this.posY1 = posY1;
                this.posX2 = posX2;
                this.posY2 = posY2;
                this.image = image;
            }

            public static void drawSquare(BeautifulSquare sq, object sender, System.Windows.Forms.PaintEventArgs e)
            {
                for (int i = sq.posY1; i < sq.posY2; i += 25)
                {
                    for (int j = sq.posX1; j < sq.posX2; j += 25)
                    {
                        e.Graphics.DrawImage(sq.image, j, i, sq.image.Width, sq.image.Height);
                    }
                }
            }
        }

        [Serializable]
        public class ScenicObject : Stuff
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public bool noclip { get; set; }
            public System.Drawing.Image image;

            public ScenicObject() // Беспараметричный конструктор
            {
                X = 0;
                Y = 0;
                Width = 0;
                Height = 0;
                noclip = true;
                image = Zamki.Properties.Resources.invisible;
            }

            public ScenicObject(int X, int Y, bool noclip, int Width, int Height, System.Drawing.Image image) // Конструктор
            {
                this.X = X;
                this.Y = Y;
                this.noclip = noclip;
                this.Width = Width;
                this.Height = Height;
                this.image = image;
            }

            public static void drawObject(ScenicObject obct, object sender, System.Windows.Forms.PaintEventArgs e)
            {
                for (int i = obct.Y; i < obct.Y + obct.Height; i += 25)
                {
                    for (int j = obct.X; j < obct.X + obct.Width; j += 25)
                    {
                        e.Graphics.DrawImage(obct.image, j, i, obct.image.Width, obct.image.Height);
                    }
                }
            }
        }

        [Serializable]
        public class Player : Stuff
        {
            public int posX;
            public int posY;
            public System.Drawing.Image image;

            public Player()
            {
                //posX = 589; Эти координаты были уместны, когда приходилось в прошлом прятать игрока за кнопкой переключения слайдов
                //posY = 431;
                posX = 25; // Хорошие координаты в левой-верхней части экрана
                posY = 200;
                image = Zamki.Properties.Resources.hero;
            }

            public Player(int posX, int posY, System.Drawing.Image image) // Конструктор
            {
                this.posX = posX;
                this.posY = posY;
                this.image = image;
            }
        }

        [Serializable]
        public class GameProgress: Stuff
        {
            public string name;
            public int silver;
            public string result;
            public System.Drawing.Image shield;

            public GameProgress()
            {
                this.name = "Ратник";
                this.silver = 0;
                this.result = "Вернул золото";
                this.shield = Zamki.Properties.Resources.shieldOrthodox;
            }

            public GameProgress(string name, int silver, string result, System.Drawing.Image shield) // Конструктор
            {
                this.name = name;
                this.silver = silver;
                this.result = result;
                this.shield = shield;
            }
        }
    }

}

