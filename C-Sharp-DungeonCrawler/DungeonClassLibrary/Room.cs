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
        public string NextDoor { get; set; }
        public bool IsSafe { get; set; }

        public Room(int width, int depth, int height, string floorMaterial, string wallMaterial, string nextDoor,bool isSafe)
        {
            Width = width;
            Depth = depth;
            Height = height;
            FloorMaterial = floorMaterial;
            WallMaterial = wallMaterial;
            NextDoor = nextDoor;
            IsSafe = isSafe;
        }

        public override string ToString()
        {
            return $"{Width}x{Depth}x{Height} room with {FloorMaterial} floors and {WallMaterial} walls\nOn the {NextDoor} side of the room you see the next door\n";
        }

        public static Room RandomRoom()
        {
            Random rand = new Random();
            string[] materials = new string[] { "wood", "Dirt", "Metal", "Stone", "Concrete", "Brick" };
            string[] directions = new string[] { "Left", "Right", "Opposite" };
            return new Room(rand.Next(5,50), rand.Next(5,50), rand.Next(8, 30), materials[rand.Next(5)], materials[rand.Next(5)], directions[rand.Next(3)],false );
        }
    }
}
