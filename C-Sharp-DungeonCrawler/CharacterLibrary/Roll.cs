using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    /// <summary>
    /// Simulates rolling different types of dice d4 - d100
    /// </summary>
    public class Roll
    {
        Random rand = new Random();

        public byte D4()
        {
            return (byte)rand.Next(1, 5);
        }

        public byte D6()
        {
            return (byte)rand.Next(1, 7);
        }

        public byte D8()
        {
            return (byte)rand.Next(1, 9);
        }

        public byte D10()
        {
            return (byte)rand.Next(1, 11);
        }

        public byte D12()
        {
            return (byte)rand.Next(1, 13);
        }

        public byte D20()
        {
            return (byte)rand.Next(1, 21);
        }

        public byte D100()
        {
            return (byte)rand.Next(1, 101);
        }
    }
}
