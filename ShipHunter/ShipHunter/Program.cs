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

        enum MenuChoice
        {
            Classic,
            Versus,
            LoadReplay
        }

        static void Main(string[] args)
        {
            MenuChoice choice = GetMenuChoice();
            switch (choice)
            {
                case MenuChoice.Classic:
                    PlayClassicGame();
                    break;
                case MenuChoice.Versus:
                    PlayVersusGame();
                    break;
                case MenuChoice.LoadReplay:
                    // TODO
                    break;
            }
        }

        /// <summary>
        /// Prints a message to the error output stream.
        /// </summary>
        /// <param name="errorMessage">The message to print.</param>
        static void PrintError(string errorMessage)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine();
            Console.Error.WriteLine(errorMessage);
            Console.ForegroundColor = currentColor;
        }

        /// <summary>
        /// Prints the game board and other game information to the console.
        /// </summary>
        /// <param name="activeShips">The list of active ships.</param>
        /// <param name="destroyedShips">The list of destroyed ships.</param>
        /// <param name="shipLengths">The dictionary mapping ships to their lengths.</param>
        /// <param name="board">The game board.</param>
        /// <param name="shots">The hash set of shots previously made.</param>
        /// <param name="maxMisses">The number of misses allowed.</param>
        /// <param name="misses">The number of shots that missed.</param>
        static void PrintUI(List<Ship> activeShips, List<Ship> destroyedShips, Dictionary<Ship, int> shipLengths, Ship[,] board, HashSet<Tuple<int, int>> shots, int maxMisses, int misses)
        {
            const int columnWidth = 2;
            Console.ForegroundColor = ConsoleColor.White;
            int maxRow = board.GetLength(0);
            int maxCol = board.GetLength(1);

            string header = string.Empty.PadRight(columnWidth);
            for (int col = 1; col <= maxCol; col++)
            {
                header += col.ToString().PadRight(columnWidth);
            }
            Console.WriteLine(header);

            string rowString = String.Empty;
            for (int row = 0; row < maxRow; row++)
            {
                // Print row label
                Console.Write(((char)('A' + row)).ToString().PadRight(columnWidth));

                for (int col = 0; col < 10; col++)
                {
                    string square = string.Empty;
                    Ship currentShip = board[row, col];
                    if (shots.Contains(Tuple.Create(row, col)))
                    {
                        if (currentShip != Ship.None)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            // Display the ship if it is destroyed.
                            if (destroyedShips.Contains(currentShip))
                            {
                                switch (currentShip)
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
                                }
                            }
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
        /// <returns>True if the ship can be placed at the given location and orientation; false otherwise.</returns>
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
        static Tuple<int, int> GetUserInput(int maxRow, int maxCol, HashSet<Tuple<int, int>> shots)
        {
            const string syntaxErrorMessage = "ERROR: Coordinates are a letter followed by a number (e.g. \"C2\", \"G5\", \"A6\").";
            const string invalidValueMessage = "ERROR: Input coordinates out of bounds.";
            const string repeatShotMessage = "ERROR: Coordinates already shot. Enter new coordinates.";

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
                    PrintError(syntaxErrorMessage);
                }
                else if (!char.IsLetter(input[0]) || (!int.TryParse(input.Substring(1), out col)))
                {
                    PrintError(syntaxErrorMessage);
                }
                else
                {
                    row = char.ToUpper(input[0]) - 'A';
                    col--;
                    if ((row >= maxRow || row < 0) || (col >= maxCol || col < 0))
                    {
                        PrintError(invalidValueMessage);
                    }
                    else
                    {
                        coordinates = Tuple.Create(row, col);
                        if (shots.Contains(coordinates))
                        {
                            PrintError(repeatShotMessage);
                        }
                        else
                        {
                            success = true;
                        }
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

        /// <summary>
        /// Prompts the user to input a choice for the main menu and returns a valid choice.
        /// </summary>
        /// <returns>The MenuChoice corresponding to the input.</returns>
        static MenuChoice GetMenuChoice()
        {
            const string invalidChoiceMessage = "ERROR: Invalid choice";

            Console.WriteLine(string.Empty.PadLeft(40, '#'));
            Console.WriteLine("Welcome to Ship Hunter!");
            Console.WriteLine(string.Empty.PadLeft(40, '#'));
            bool choiceMade = false;
            MenuChoice choice = MenuChoice.Classic;
            do
            {
                Console.WriteLine();
                Console.WriteLine(string.Empty.PadLeft(30, '='));
                Console.WriteLine(" 1) Classic");
                Console.WriteLine(" 2) Versus");
                Console.WriteLine(" 3) Load Replay");
                Console.WriteLine(string.Empty.PadLeft(30, '='));
                Console.Write("Enter a number: ");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        choice = MenuChoice.Classic;
                        choiceMade = true;
                        break;
                    case '2':
                        choice = MenuChoice.Versus;
                        choiceMade = true;
                        break;
                    case '3':
                        choice = MenuChoice.LoadReplay;
                        choiceMade = true;
                        break;
                    default:
                        PrintError(invalidChoiceMessage);
                        break;
                }
            }
            while (!choiceMade);

            return choice;
        }

        /// <summary>
        /// Starts a classic game. 
        /// The player tries to guess where the computer has placed ships on the game board.
        /// Ends when the player makes too many mistakes or when the player finds all ships.
        /// </summary>
        static void PlayClassicGame()
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
            var board = new Ship[10, 10];
            var shots = new HashSet<Tuple<int, int>>();

            foreach (Ship ship in activeShips)
            {
                PlaceShip(ship, shipLengths[ship], board);
            }

            bool gameWin = false;
            while (!gameWin && misses < maxMisses)
            {
                Console.Clear();
                PrintUI(activeShips, destroyedShips, shipLengths, board, shots, maxMisses, misses);
                var newShot = GetUserInput(board.GetLength(0), board.GetLength(1), shots);
                shots.Add(newShot);
                if (board[newShot.Item1, newShot.Item2] == Ship.None)
                {
                    misses++;
                }
                foreach (Ship ship in activeShips)
                {
                    if (ShipIsDestroyed(ship, shipLengths[ship], board, shots))
                    {
                        activeShips.Remove(ship);
                        destroyedShips.Add(ship);
                        break;
                    }
                }
                if (activeShips.Count == 0)
                {
                    gameWin = true;
                }
            }

            Console.Clear();
            PrintUI(activeShips, destroyedShips, shipLengths, board, shots, maxMisses, misses);

            if (gameWin)
            {
                Console.WriteLine();
                Console.WriteLine(string.Empty.PadLeft(40, '='));
                Console.WriteLine("Well done, Ship Hunter! You have destroyed all the ships!");
                Console.WriteLine(string.Empty.PadLeft(40, '='));
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(string.Empty.PadLeft(40, '='));
                Console.WriteLine("Mission failed. We'll get them next time.");
                Console.WriteLine(string.Empty.PadLeft(40, '='));
            }

            Console.ReadKey();
        }

        static void PlayVersusGame()
        {

        }
    }
}
