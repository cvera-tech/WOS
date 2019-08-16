using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipHunter
{
    class Program
    {
        enum Ship
        {
            AircraftCarrier,
            Battleship,
            Cruiser,
            Destroyer,
            Submarine
        }
        static void Main(string[] args)
        {
            var activeShips = new List<Ship>() {
                Ship.AircraftCarrier,
                Ship.Battleship,
                Ship.Cruiser,
                Ship.Destroyer,
                Ship.Destroyer,
                Ship.Submarine,
                Ship.Submarine
                };
            var destroyedShips = new List<Ship>();
            PrintUI();
            Console.ReadKey();
        }
        static void PrintUI(/*List<Ship> activeShips, List<Ship> destroyedShips, HashSet<Tuple<int, int>> shots*/)
        {
            const int columnWidth = 2;

            string header = String.Empty.PadRight(columnWidth);
            for (int col = 1; col <= 10; col++)
            {
                header += col.ToString().PadRight(columnWidth);
            }
            Console.WriteLine(header);

            string rowString = String.Empty;
            for (int row = 0; row < 10; row++)
            {
                // Print row
                Console.Write(((char)('A' + row)).ToString().PadRight(columnWidth));
                for (int col = 0; col < 10; col++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
        }
    }
}
