using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Room
    {
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
        public string FloorMaterial { get; set; }
        public string WallMaterial { get; set; }
        public bool IsSafe { get; set; }

        public Room(int width, int depth, int height, string floorMaterial, string wallMaterial, bool isSafe)
        {
            Width = width;
            Depth = depth;
            Height = height;
            FloorMaterial = floorMaterial;
            WallMaterial = wallMaterial;
            IsSafe = isSafe;
        }

        public override string ToString()
        {
            return $"{Width}x{Depth}x{Height} room with {FloorMaterial} floors and {WallMaterial} walls\n";
        }

        public static Room RandomRoom()
        {
            Random rand = new Random();
            string[] materials = new string[] { "wood", "Dirt", "Metal", "Stone", "Concrete", "Brick" };
            return new Room(rand.Next(5,50), rand.Next(5,50), rand.Next(8, 30), materials[rand.Next(5)], materials[rand.Next(5)], false );
        }
    }
}
