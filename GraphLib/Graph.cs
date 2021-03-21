using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphLib
{
    public class Graph
    {
        public List<Door> Doors = new List<Door>();

        public static Graph Load()
        {
            Graph g = new Graph();
            g.Doors.Add(new Door() { X = 50, Y = 130, horizontal = false});
            return g;
        }
    }
}

