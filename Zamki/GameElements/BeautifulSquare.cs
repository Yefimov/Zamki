//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Zamki
//{
//    [Serializable]
//    public class BeautifulSquare : Elements.Elements.Stuff // Закрашиваемые площади (полы, например)
//    {
//        public int posX1;
//        public int posY1;
//        public int posX2;
//        public int posY2;
//        public System.Drawing.Image image;

//        public BeautifulSquare()
//        {
//            posX1 = 0;
//            posY1 = 0;
//            posY2 = 0; 
//            posX2 = 0;
//            image = Zamki.Properties.Resources.invisible;
//        }

//        public BeautifulSquare(int posX1, int posY1, int posX2, int posY2, System.Drawing.Image image) // Конструктор
//        {
//            this.posX1 = posX1;
//            this.posY1 = posY1;
//            this.posX2 = posX2;
//            this.posY2 = posY2;
//            this.image = image;
//        }

//        public static void drawSquare(BeautifulSquare sq, object sender, System.Windows.Forms.PaintEventArgs e)
//        {
//            for (int i = sq.posY1; i < sq.posY2; i += 25)
//            {
//                for (int j = sq.posX1; j < sq.posX2; j += 25)
//                {
//                    e.Graphics.DrawImage(sq.image, j, i, sq.image.Width, sq.image.Height);
//                }
//            }
//        }
//    }
//}
