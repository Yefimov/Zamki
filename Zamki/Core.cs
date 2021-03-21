using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Zamki
{
    class Core
    {
        public static void setDoorStatus(GameElements.Stuff.ScenicObject door, bool isDoor)
        {
            if (isDoor)
            {
                door.image = Zamki.Properties.Resources.door_ultima;
                door.noclip = true;
            }
            else
            {
                door.image = Zamki.Properties.Resources.wall_castle;
                door.noclip = false;
            }
        }

        public static void generateLevel(List<GameElements.Stuff.ScenicObject> allDoors, List<GameElements.Stuff.ScenicObject> allObjects, List<GameElements.Stuff.BeautifulSquare> allRooms, GameElements.Stuff.Player hero)
        {
            Random rnd = new Random();
            int r = rnd.Next(5);
            string stream;
            switch (r)
            {
                case 0:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @"\\Levels\\level0.bin");
                        break;
                    }
                case 1:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @".\\Levels\\level1.bin");
                        break;
                    }
                case 2:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @".\\Levels\\level2.bin");
                        break;
                    }
                case 3:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @".\\Levels\\level3.bin");
                        break;
                    }
                case 4:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @".\\Levels\\level4.bin");
                        break;
                    }
                default:
                    {
                        stream = Path.GetFullPath(System.Windows.Forms.Application.StartupPath + @".\\Levels\\level0.bin");
                        break;
                    }
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(stream, FileMode.OpenOrCreate))
            {
                List<GameElements.Stuff> stuff = (List<GameElements.Stuff>)formatter.Deserialize(fs);
                GameElements.Stuff.BeautifulSquare z = new GameElements.Stuff.BeautifulSquare(0, 0, 0, 0, Zamki.Properties.Resources.invisible);
                GameElements.Stuff.ScenicObject y = new GameElements.Stuff.ScenicObject(0, 0, true, 0, 0, Zamki.Properties.Resources.invisible);
                GameElements.Stuff.Player x = new GameElements.Stuff.Player(25, 200, Zamki.Properties.Resources.hero);

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
                            else
                            allObjects.Add(sy);
                        }
                        //else
                        //    if (Object.ReferenceEquals(s.GetType(), x.GetType()))
                        //    {
                        //        object xs = s;
                        //        GameElements.Stuff.Player sx = (GameElements.Stuff.Player)xs;
                        //        if (sx.posX == 999)
                        //        {
                        //            sx.posX = 25;
                        //            sx.posY = 25;
                        //        }
                        //        hero = sx;
                        //    }
                }
            }
        }

        public static void generateDoors(List<GameElements.Stuff.ScenicObject> allDoors)
        {
            Random rnd = new Random();
            int r;
            foreach (GameElements.Stuff.ScenicObject door in allDoors)
            {
                r = rnd.Next(99);
                if (r < 25)
                {
                    setDoorStatus(door, false);
                }
                else
                {
                    setDoorStatus(door, true);
                }
            }
        }

        public static bool inTheRoom(GameElements.Stuff.BeautifulSquare room, GameElements.Stuff.Player hero)
        {
            System.Drawing.Rectangle heroBounds = new System.Drawing.Rectangle(hero.posX, hero.posY, hero.image.Width, hero.image.Height);
            int border = 40; // Чтобы игрок не мог зайти в одну комнату "одной ногой" и сразу же вернуться в первую, закрыв тем самым дверь путём обмана
            System.Drawing.Rectangle roomRectangle = new System.Drawing.Rectangle(room.posX1 + border, room.posY1 + border, room.posX2 - room.posX1 - border, room.posY2 - room.posY1 - border);
            if (heroBounds.IntersectsWith(roomRectangle))
            {
                return true;
            }
            return false;
        }

        public static bool clash(int ulX, int ulY, List<GameElements.Stuff.ScenicObject> Objects) // ul - up left
        {
            int playerWidth = 25;
            System.Drawing.Rectangle heroBounds = new System.Drawing.Rectangle(ulX, ulY, playerWidth, playerWidth);
            System.Drawing.Rectangle obctBounds;
            foreach (GameElements.Stuff.ScenicObject obct in Objects)
            {
                if (!obct.noclip)
                {
                    obctBounds = new System.Drawing.Rectangle(obct.X, obct.Y+3, obct.Width-3, obct.Height-6);
                    if (heroBounds.IntersectsWith(obctBounds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void touchTheDoor(List<GameElements.Stuff.ScenicObject> allDoors, GameElements.Stuff.Player hero, GameElements.Stuff.BeautifulSquare previousRoom, GameElements.Stuff.BeautifulSquare currentRoom)
        {
            System.Drawing.Rectangle heroBounds = new System.Drawing.Rectangle(hero.posX, hero.posY, hero.image.Width, hero.image.Height);
            System.Drawing.Rectangle previousRoomRectangle = new System.Drawing.Rectangle(previousRoom.posX1, previousRoom.posY1, previousRoom.posX2 - previousRoom.posX1, previousRoom.posY2 - previousRoom.posY1);
            System.Drawing.Rectangle currentRoomRectangle = new System.Drawing.Rectangle(currentRoom.posX1, currentRoom.posY1, currentRoom.posX2 - currentRoom.posX1, currentRoom.posY2 - currentRoom.posY1);
            foreach (GameElements.Stuff.ScenicObject door in allDoors)
            {
                System.Drawing.Rectangle doorBounds = new System.Drawing.Rectangle(door.X + 5, door.Y, door.Width - 5, door.Height); // "Сузил" двери на 5 пикселей справа и слева. Почему? Потому что я могу.
                if (previousRoomRectangle != currentRoomRectangle)
                {
                    if (doorBounds.IntersectsWith(previousRoomRectangle) && doorBounds.IntersectsWith(currentRoomRectangle))
                    {
                        if (!doorBounds.IntersectsWith(heroBounds))
                        {
                            door.noclip = false;
                            //allDoors.Remove(door); // По-хорошему надо бы удалять ту дверь, которую уже закрыли, из массива allDoors, потому что он нигде не используется, а так дверь будет лишний раз "прогоняться" в foreach. Но я не стал удалять, потому что, по-моему, иначе после загрузки сохранения на мести двери окажется пустое место
                            break;
                        }
                    }
                }
            }
        }



        public static bool isWin(List<GameElements.Stuff.ScenicObject> allDoors)
        {
            foreach (GameElements.Stuff.ScenicObject d in allDoors)
            {
                if (d.noclip)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
