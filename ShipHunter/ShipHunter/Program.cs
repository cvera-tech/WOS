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

            var shots = new HashSet<Tuple<int, int>>();

            //foreach (Ship ship in activeShips)
            //{
            //    PlaceShip(ship, shipLengths[ship], board);
            //}

            //bool gameWin = false;
            //while (!gameWin)
            //{
            //    Console.Clear();
            //    PrintUI(activeShips, destroyedShips, shipLengths, board, shots, maxMisses, misses);
            //    var shot = GetUserInput(board.GetLength(0), board.GetLength(1));
            //    Console.WriteLine(shot);
            //    Console.ReadKey();
            //}

            //ProcessUserInput(shot);
            Console.ReadKey();
        }

        static void PrintUI(List<Ship> activeShips, List<Ship> destroyedShips, Dictionary<Ship, int> shipLengths, Ship[,] board, HashSet<Tuple<int, int>> shots, int maxMisses, int misses)
        {
            const int columnWidth = 2;
            Console.ForegroundColor = ConsoleColor.White;

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

                    string square = string.Empty;
                    switch (board[row, col])
                    {
                        case Ship.AircraftCarrier:
                            square = "AC";
                            break;
                        case Ship.Battleship:
                            square = "BS";
                            break;
                        case Ship.Cruiser:
                            square = "CR";
                            break;
                        case Ship.Destroyer1:
                            square = "D1";
                            break;
                        case Ship.Destroyer2:
                            square = "D2";
                            break;
                        case Ship.Submarine1:
                            square = "S1";
                            break;
                        case Ship.Submarine2:
                            square = "S2";
                            break;
                        default:
                            square = "  ";
                            break;
                    }
                    Console.Write(square.PadLeft(columnWidth));
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            Console.WriteLine($"Number of misses allowed: {maxMisses - misses}");
            Console.WriteLine("Ships remaining:");
            foreach (Ship ship in activeShips)
            {
                Console.WriteLine($" > {ship} ({shipLengths[ship]})");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Places a given ship on the board.
        /// </summary>
        /// <param name="ship">The ship to place.</param>
        /// <param name="shipLength">The length of the ship.</param>
        /// <param name="board">The game board.</param>
        static void PlaceShip(Ship ship, int shipLength, Ship[,] board)
        {
            // A more robust solution probably requires checking for all empty contiguous 
            // squares (similar to the memory fragmentation problem). If there are no spaces 
            // large enough, the ship cannot be placed on the board.
            Random rng = new Random();
            bool success = false;
            while (!success)
            {
                int row = rng.Next(0, 10);
                int col = rng.Next(0, 10);
                var coordinates = Tuple.Create(row, col);
                bool horizontal = rng.Next(0, 2) == 0 ? true : false;
                if (PlaceIsValid(board, coordinates, horizontal, shipLength))
                {
                    for (int counter = 0; counter < shipLength; counter++)
                    {
                        if (horizontal)
                        {
                            board[row, col + counter] = ship;
                        }
                        else
                        {
                            board[row + counter, col] = ship;
                        }
                    }
                    success = true;
                }
            }
        }

        /// <summary>
        /// Checks whether or not a ship can fit in the board at a given location and orientation.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="coordinates">The row and column tuple to check.</param>
        /// <param name="horizontal">True if ship is horizontal; false if it is vertical</param>
        /// <param name="shipLength">The length of the ship.</param>
        /// <returns>True if the ship can be placed at the given location and orientation. False otherwise.</returns>
        static bool PlaceIsValid(Ship[,] board, Tuple<int, int> coordinates, bool horizontal, int shipLength)
        {
            // Check board boundaries
            if (horizontal && coordinates.Item2 + shipLength > board.GetLength(1))
            {
                return false;
            }
            else if (!horizontal && coordinates.Item1 + shipLength > board.GetLength(0))
            {
                return false;
            }
            else
            {
                bool isValid = true;
                for (int counter = 0; counter < shipLength; counter++)
                {
                    int row = coordinates.Item1;
                    int col = coordinates.Item2;
                    if (horizontal)
                    {
                        col += counter;
                    }
                    else
                    {
                        row += counter;
                    }
                    if (board[row, col] != Ship.None)
                    {
                        isValid = false;
                    }
                }
                return isValid;
            }
        }

        /// <summary>
        /// Prompts the user for input and returns a valid tuple.
        /// </summary>
        /// <param name="maxRow">The row upper boundary.</param>
        /// <param name="maxCol">The column upper boundary.</param>
        /// <returns>The valid coordinates tuple.</returns>
        static Tuple<int, int> GetUserInput(int maxRow, int maxCol)
        {
            const string syntaxErrorMessage = "ERROR: Coordinates are a letter followed by a number (e.g. \"C2\", \"G5\", \"A6\")";
            const string invalidValueMessage = "ERROR: Input coordinates out of bounds";

            bool success = false;
            Tuple<int, int> coordinates = Tuple.Create(-1, -1);
            do
            {
                int row;
                int col;
                Console.Write("Enter coordinates: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Error.WriteLine(syntaxErrorMessage);
                }
                else if (!char.IsLetter(input[0]) || (!int.TryParse(input.Substring(1), out col)))
                {
                    Console.Error.WriteLine(syntaxErrorMessage);
                }
                else
                {
                    row = char.ToUpper(input[0]) - 'A';
                    col--;
                    if ((row >= maxRow || row < 0) || (col >= maxCol || col < 0))
                    {
                        Console.Error.WriteLine(invalidValueMessage);
                    }
                    else
                    {
                        coordinates = Tuple.Create(row, col);
                        success = true;
                    }
                }
            }
            while (!success);
            return coordinates;
        }

        /// <summary>
        /// Returns whether or not all a ship's squares have been hit.
        /// </summary>
        /// <param name="ship">The ship to check.</param>
        /// <param name="shipLength">The length of the ship.</param>
        /// <param name="board">The game board.</param>
        /// <param name="shots">The list of shots already made.</param>
        /// <returns>True if the ship is destroyed; false otherwise.</returns>
        static bool ShipIsDestroyed(Ship ship, int shipLength, Ship[,] board, HashSet<Tuple<int, int>> shots)
        {
            int squaresHit = 0;
            foreach (var shotCoordinates in shots)
            {
                if (board[shotCoordinates.Item1, shotCoordinates.Item2] == ship)
                {
                    squaresHit++;
                }
            }
            if (squaresHit == shipLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
