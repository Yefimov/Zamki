using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace Zamki
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (currentSlide == 6)
            {
                foreach (GameElements.Stuff.BeautifulSquare sq in allRooms) // Рисуется пол каждой комнаты (в том числе выход из комнаты на улицу)
                {
                    GameElements.Stuff.BeautifulSquare.drawSquare(sq, sender, e);
                }

                foreach (GameElements.Stuff.ScenicObject obct in allObjects) // Рисуется каждый объект
                {
                    if (!obct.noclip)
                    {
                        GameElements.Stuff.ScenicObject.drawObject(obct, sender, e);
                    }
                }

                e.Graphics.DrawImage(picPlayer, hero.posX, hero.posY, hero.image.Width, hero.image.Height); // Рисуется игрок
                e.Graphics.DrawImage(GP.shield, hero.posX + 1, hero.posY + 7, 12, 13); // Рисуется щит
            }
            else
            {
                switch (currentSlide)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            this.BackgroundImage = Zamki.Properties.Resources.slide2;
                            break;
                        }
                    case 3:
                        {
                            this.BackgroundImage = Zamki.Properties.Resources.slide3;
                            break;
                        }
                    case 4:
                        {
                            this.BackgroundImage = Zamki.Properties.Resources.slide4;
                            break;
                        }
                    case 5:
                        {
                            this.BackgroundImage = Zamki.Properties.Resources.slide5;
                            btnArrowLeft.Visible = true;
                            btnArrowRight.Visible = true;
                            tbName.Visible = true;

                            switch (currentShieldNumber)
                            {
                                case 0:
                                    {
                                        bigShield = Zamki.Properties.Resources.bigOrthodox;
                                        GP.shield = Zamki.Properties.Resources.shieldOrthodox;
                                        break;
                                    }
                                case 1:
                                    {
                                        bigShield = Zamki.Properties.Resources.bigCherry;
                                        GP.shield = Zamki.Properties.Resources.shieldCherry;
                                        break;
                                    }
                            }
                            e.Graphics.DrawImage(bigShield, 210, 162, 50, 54);
                            break;
                        }
                    default: break;
                }
            }

            if (Core.isWin(allDoors) && !isOk)
            {
                Random rnd = new Random();
                //int r = rnd.Next(101);
                int r = 90;
                if (showWin)
                {
                    if (r < 91)
                    {
                        winCastle wc = new winCastle(isOk);
                        wc.Show();

                        if (isOk)
                        {
                            btnSave.Visible = true;
                            btnLoad.Visible = true;
                            btnNew.Visible = true;
                        }

                        showWin = false;
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnLoad.Visible = false;
                        btnNew.Visible = false;

                        winGame wg = new winGame(isOk, GP);
                        wg.Show();

                        if (isOk)
                        {
                            allGP.Add(GP);
                            saveData();
                            eraseData();
                            this.BackgroundImage = Zamki.Properties.Resources.mainMenu;
                            showTable(); //TODO Сохранение и отображение таблицы рекордов после прохождения игры
                        }

                        showWin = false;
                    }
                }
            }

        }

        //Загрузка всех изображений проекта, чтобы не вызывать из ресурсов картиночки каждый раз
        static Image picPlayer = Zamki.Properties.Resources.hero;
        static Image picInvisible = Zamki.Properties.Resources.invisible;
        static Image picWall = Zamki.Properties.Resources.wall_castle;
        static Image picDoor = Zamki.Properties.Resources.door_ultima;
        static Image picFloor = Zamki.Properties.Resources.floor;
        static Image picFloorYellow = Zamki.Properties.Resources.floor_yellow;
        static Image picFloorYellow1 = Zamki.Properties.Resources.floor_yellow1;
        static Image picFloorBrown = Zamki.Properties.Resources.floor_brown;
        static Image picFloorBlue = Zamki.Properties.Resources.floor_blue2;
        static Image picFloorWood = Zamki.Properties.Resources.floor_wood;

        System.Drawing.Image bigShield = Zamki.Properties.Resources.bigOrthodox; // При выборе раскраски щита сперва демонстрируется вариант с крестом
        //GameElements.Stuff.Player hero = new GameElements.Stuff.Player(25, 200, picPlayer); // Почему-то нарисуется игрок на этих координатах, а фактическое его местонахождение будет определяться описанными координатами из пустого конструктора в Core
        GameElements.Stuff.Player hero = new GameElements.Stuff.Player(); // Экземпляр класса Игрок

        List<GameElements.Stuff.GameProgress> allGP = new List<GameElements.Stuff.GameProgress>();
        GameElements.Stuff.GameProgress GP = new GameElements.Stuff.GameProgress();
        List<GameElements.Stuff.BeautifulSquare> allRooms = new List<GameElements.Stuff.BeautifulSquare>();
        List<GameElements.Stuff.ScenicObject> allObjects = new List<GameElements.Stuff.ScenicObject>();
        List<GameElements.Stuff.ScenicObject> allDoors = new List<GameElements.Stuff.ScenicObject>();
        GameElements.Stuff.BeautifulSquare currentRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);
        GameElements.Stuff.BeautifulSquare previousRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);
        int currentSlide = 0;
        int currentShieldNumber = 0;
        bool startNewGame = false;
        bool showWin = true; // Показывать ли окно победы на уровне или в игре
        bool isOk = true; // Принял ли игрок решение после победы на уровне или в игре

        private void MainForm_Load(object sender, EventArgs e)
        {
            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, -25, false, 800, 25, picWall)); // Границы карты
            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, -25, false, 25, 575, picWall));
            allObjects.Add(new GameElements.Stuff.ScenicObject(760, -25, false, 25, 575, picWall));
            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, 515, false, 800, 25, picWall));
            Invalidate(); // Чтобы не "моргало" и не удалялось после выхода окна за границу экрана
        }

        public void getSilver()
        {
            Random rnd = new Random();
            int r = rnd.Next(901);
            if (r < 6)
            {
                DialogResult Del = MessageBox.Show("Благодаря недюжинной находчивости вам удалось обнаружить мешочек серебрянных драгоценностей", "Найдено серебро", MessageBoxButtons.OK);
                if (Del == DialogResult.OK)
                {
                    GP.silver += 25;
                }
            }
        }

        public void changeRoom()
        {
            foreach (GameElements.Stuff.BeautifulSquare room in allRooms) // Проверка, в какой игрок комнате
            {
                if (room != currentRoom)
                {
                    if (Core.inTheRoom(room, hero))
                    {
                        previousRoom = currentRoom;
                        currentRoom = room;
                        getSilver();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // Работа с кнопками-стрелками на клавиатуре (перемещение персонажа с учётом стен, дверей и декоративных объектов)
        {
            switch (keyData)
            {
                case Keys.Left:
                    {
                        changeRoom();

                        if (!Core.clash(hero.posX - 5, hero.posY, allObjects))
                        {
                            hero.posX -= 5;
                            Invalidate();
                        }

                        Core.touchTheDoor(allDoors, hero, previousRoom, currentRoom);

                        break;
                    }

                case Keys.Right:
                    {
                        changeRoom();

                        if (!Core.clash(hero.posX + 5, hero.posY, allObjects))
                        {
                            hero.posX += 5;
                            Invalidate();
                        }

                        Core.touchTheDoor(allDoors, hero, previousRoom, currentRoom);

                        break;
                    }

                case Keys.Up:
                    {
                        changeRoom();



                        if (!Core.clash(hero.posX, hero.posY - 5, allObjects))
                        {
                            hero.posY -= 5;
                            Invalidate();
                        }

                        Core.touchTheDoor(allDoors, hero, previousRoom, currentRoom);

                        break;
                    }

                case Keys.Down:
                    {
                        changeRoom();

                        if (!Core.clash(hero.posX, hero.posY + 5, allObjects))
                        {
                            hero.posY += 5;
                            Invalidate();
                        }

                        Core.touchTheDoor(allDoors, hero, previousRoom, currentRoom);

                        break;
                    }

                default: return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            hero.posX = 25;  // Возвращение игрока на стартовую позицию
            hero.posY = 200;

            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, -25, false, 800, 25, picWall)); // Границы карты
            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, -25, false, 25, 575, picWall));
            allObjects.Add(new GameElements.Stuff.ScenicObject(760, -25, false, 25, 575, picWall));
            allObjects.Add(new GameElements.Stuff.ScenicObject(-25, 515, false, 800, 25, picWall));

            currentRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);
            previousRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);


            this.BackgroundImage = Zamki.Properties.Resources.grass;
            eraseData();
            Core.generateLevel(allDoors, allObjects, allRooms, hero);
            Euler();

            Invalidate(); // Перерисовка карты
            showWin = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
            Type[] extraTypes = new Type[3];
            extraTypes[0] = typeof(GameElements.Stuff.BeautifulSquare);
            extraTypes[1] = typeof(GameElements.Stuff.ScenicObject);
            extraTypes[2] = typeof(GameElements.Stuff.Player);

            XmlSerializer XMLformatter = new XmlSerializer(typeof(List<GameElements.Stuff>), extraTypes);
            using (FileStream xfs = new FileStream("lvl.xml", FileMode.OpenOrCreate))
            {
                XMLformatter.Serialize(xfs, stuff);
            }
            */

            saveData();
        }

        public void saveData()
        {
            List<GameElements.Stuff> stuff = new List<GameElements.Stuff>();
            stuff.AddRange(allRooms);
            stuff.AddRange(allObjects);
            stuff.Add(hero);
            stuff.AddRange(allGP);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("save.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, stuff);
            }
        }

        public void eraseData()
        {
            allDoors.Clear();
            allObjects.Clear();
            allRooms.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            eraseData();
            isOk = false;
            btnLoad.Visible = true;
            btnSave.Visible = true;
            btnNew.Visible = true;
            LoadFromFile();
        }

        private void btnDownload_Click(object sender, EventArgs e) //TODO После загрузки не засчитывается прохождение уровня. Там формируется какая-то вторая дверь, которую даже не видно. Естественно, она всегда будет noclip и никогда не сбудется условие Core.isWin
        {
            eraseData();
            currentSlide = 6;
            isOk = false;
            btnLoad.Visible = true;
            btnSave.Visible = true;
            btnNew.Visible = true;
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            this.BackgroundImage = Zamki.Properties.Resources.grass;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("save.bin", FileMode.OpenOrCreate))
            {
                List<GameElements.Stuff> stuff = (List<GameElements.Stuff>)formatter.Deserialize(fs);
                GameElements.Stuff.BeautifulSquare z = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, picInvisible);
                GameElements.Stuff.ScenicObject y = new GameElements.Stuff.ScenicObject(0, 0, true, 0, 0, picInvisible);
                GameElements.Stuff.Player x = new GameElements.Stuff.Player(25, 200, picPlayer);
                GameElements.Stuff.GameProgress w = new GameElements.Stuff.GameProgress();

                foreach (GameElements.Stuff s in stuff)
                {
                    if (Object.ReferenceEquals(s.GetType(), z.GetType()))
                    {
                        object zs = s;
                        GameElements.Stuff.BeautifulSquare sz = (GameElements.Stuff.BeautifulSquare)zs;
                        allRooms.Add(sz);
                    }
                    else
                        if (Object.ReferenceEquals(s.GetType(), y.GetType()))
                        {
                            object ys = s;
                            GameElements.Stuff.ScenicObject sy = (GameElements.Stuff.ScenicObject)ys;
                            if (sy.noclip)
                            {
                                allDoors.Add(sy);
                            }
                            allObjects.Add(sy);
                        }
                        else
                            if (Object.ReferenceEquals(s.GetType(), x.GetType()))
                            {
                                object xs = s;
                                GameElements.Stuff.Player sx = (GameElements.Stuff.Player)xs;
                                hero = sx;
                            }
                            else
                                if (Object.ReferenceEquals(s.GetType(), w.GetType()))
                                {
                                    object ws = s;
                                    GameElements.Stuff.GameProgress sw = (GameElements.Stuff.GameProgress)ws;
                                    allGP.Add(sw);
                                }
                }
            }
            currentRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);
            previousRoom = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, null);
            picNextPage.Visible = false;

            hideMenuButtons();
            Invalidate();
        }

        public void hideMenuButtons()
        {
            btnAbout.Visible = false;
            btnDownload.Visible = false;
            btnNewGame.Visible = false;
            btnTable.Visible = false;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            startNewGame = true;
            dataGridView1.Visible = false;
            picNextPage.Image = Zamki.Properties.Resources.btnNextPage;
            this.BackgroundImage = Zamki.Properties.Resources.slide1;
            picNextPage.Visible = true;
            hideMenuButtons();
            currentSlide = 1;
            showWin = true;
            Invalidate();
        }

        private void picNextPage_Click(object sender, EventArgs e)
        {
            if (startNewGame)
            {
                if (currentSlide < 5)
                {
                    currentSlide++;
                }
                else
                {
                    currentSlide = 6;
                    picNextPage.Visible = false;
                    btnArrowLeft.Visible = false;
                    btnArrowRight.Visible = false;
                    if (tbName.Text != string.Empty)
                    {
                        GP.name = tbName.Text;
                    }
                    else
                        GP.name = "Имярек";
                    tbName.Visible = false;
                    this.BackgroundImage = Zamki.Properties.Resources.grass;
                    Core.generateLevel(allDoors, allObjects, allRooms, hero);
                    Euler();
                    btnLoad.Visible = true;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    isOk = false;
                }
                Invalidate();
            }
        }

        public void Euler() //TODO Метод Euler как-то неправильно конструирует уровни. Быть может, слишком высока вероятность бракованного уровня?
        {
            int oddNumber = 0;

            List<GameElements.Stuff.ScenicObject> allDoorsNew = new List<GameElements.Stuff.ScenicObject>();
            allDoorsNew.AddRange(allDoors);

            Core.generateDoors(allDoors);
            Random rnd = new Random();
            int r = rnd.Next(101);
            foreach (GameElements.Stuff.BeautifulSquare sq in allRooms)
            {
                System.Drawing.Rectangle sqBounds = new System.Drawing.Rectangle(sq.posX1, sq.posY1, sq.posX2 - sq.posX1, sq.posY2 - sq.posY1);
                int power = 0;
                foreach (GameElements.Stuff.ScenicObject obct in allObjects)
                {
                    if (obct.image != Zamki.Properties.Resources.door_ultima)
                    {
                        if (sqBounds.IntersectsWith(new System.Drawing.Rectangle(obct.X, obct.Y, obct.Width, obct.Height)))
                        {
                            power++;
                        }
                    }
                }
                if (power % 2 != 0)
                {
                    allDoorsNew.Clear();
                    oddNumber++;
                }
            }
            if (oddNumber > 6) // Проблема с невидимыми полами-выходами
            {
                if (allDoorsNew.Count() < 10)
                {
                    //if (r > 10)
                    if (r > 0)
                    {
                        Euler();
                    }
                }
                else
                    if (oddNumber > 10)
                    {
                        //if (r > 10)
                        if (r > 0)
                        {
                            Euler();
                        }
                    }
            }
            else
                allObjects.AddRange(allDoors);
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            currentShieldNumber--;
            if (currentShieldNumber < 0)
            {
                currentShieldNumber = 1;
            }
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            currentShieldNumber++;
            if (currentShieldNumber > 1)
            {
                currentShieldNumber = 0;
            }
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Имя");
            dt.Columns.Add("Серебро");
            dt.Columns.Add("Итог");
            DataRow dr = dt.NewRow();
            foreach (GameElements.Stuff.GameProgress g in allGP)
            {
                //dr["Имя"] = GP.name;
                //dr["Серебро"] = GP.silver;
                //dr["Итог"] = GP.result;
                //dt.Rows.Add(dr);
            }

            dr["Имя"] = GP.name;
            dr["Серебро"] = GP.silver;
            dr["Итог"] = GP.result;
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

            Point p = new Point(160, 459);
            hideMenuButtons();
            btnNewGame.Visible = true;
            btnNewGame.Location = p;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            DialogResult Del = MessageBox.Show("Автор приложения: Ефимов Илья Сергеевич\nПреподаватель: Портенко Марина Сергеевна\n\nСпасибо Владиславу Саргас за помощь с дизайном", "Об игре", MessageBoxButtons.OK);
        }
    }
}

