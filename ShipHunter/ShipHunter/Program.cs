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
            None,
            AircraftCarrier,
            Battleship,
            Cruiser,
            Destroyer1,
            Destroyer2,
            Submarine1,
            Submarine2
        }

        static void Main(string[] args)
        {
            const int maxMisses = 25;
            int misses = 0;

            Dictionary<Ship, int> shipLengths = new Dictionary<Ship, int>();
            shipLengths.Add(Ship.AircraftCarrier, 5);
            shipLengths.Add(Ship.Battleship, 4);
            shipLengths.Add(Ship.Cruiser, 3);
            shipLengths.Add(Ship.Destroyer1, 2);
            shipLengths.Add(Ship.Destroyer2, 2);
            shipLengths.Add(Ship.Submarine1, 1);
            shipLengths.Add(Ship.Submarine2, 1);

            var activeShips = new List<Ship>() {
                Ship.AircraftCarrier,
                Ship.Battleship,
                Ship.Cruiser,
                Ship.Destroyer1,
                Ship.Destroyer2,
                Ship.Submarine1,
                Ship.Submarine2
            };
            var destroyedShips = new List<Ship>();

            // Default value is Ship.None
            var board = new Ship[10, 10];
            board[0, 5] = Ship.AircraftCarrier;
            //board[0, 6] = Ship.AircraftCarrier;
            //board[0, 7] = Ship.AircraftCarrier;
            //board[0, 8] = Ship.AircraftCarrier;
            //board[0, 9] = Ship.AircraftCarrier;

            var shots = new HashSet<Tuple<int, int>>();
            shots.Add(new Tuple<int, int>(0, 5));
            shots.Add(new Tuple<int, int>(0, 6));
            shots.Add(new Tuple<int, int>(3, 4));

            PrintUI(activeShips, destroyedShips, shipLengths, board, shots, maxMisses, misses);
            //var shot = GetUserInput();
            //ProcessUserInput(shot);
            Console.ReadKey();
        }
        static void PrintUI(List<Ship> activeShips, List<Ship> destroyedShips, Dictionary<Ship, int> shipLengths, Ship[,] board, HashSet<Tuple<int, int>> shots, int maxMisses, int misses)
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
                // Print row label
                Console.Write(((char)('A' + row)).ToString().PadRight(columnWidth));

                for (int col = 0; col < 10; col++)
                {
                    if (shots.Contains(new Tuple<int, int>(row, col)))
                    {
                        if (board[row, col] != Ship.None)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write("  ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            Console.WriteLine($"Number of misses allowed: {maxMisses - misses}");
            Console.WriteLine($"Ships remaining:");
            foreach (Ship ship in activeShips)
            {
                Console.WriteLine($"> {ship} ({shipLengths[ship]})");
            }

            Console.WriteLine();
            Console.Write("Enter coordinates: ");
        }

        static void PlaceShip(Ship ship, int shipLength, Ship[,] board)
        {
            bool success = false;
            while (!success)
            {

            }
        }
    }
}
