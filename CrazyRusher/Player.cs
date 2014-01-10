using System;

class Player
{
    static GameField matrix = new GameField();
    public static int row = matrix.Rows / 2;
    public static int col = matrix.Cols / 2;
    public static char playerChar = '\u263B';
    static ConsoleColor playerColor = ConsoleColor.Green;

    public static void SetPlayerCoordinates(GameField matrix)
    {
        Console.ForegroundColor = playerColor;
        matrix[row, col] = playerChar;
    }

    public static int[] MovePlayer(GameField matrix)
    {
        if (row != 0 && row != matrix.Rows - 1)
        {
            if (row - 2 >= 0 && row + 2 < matrix.Rows)
            {
                if (matrix[row - 1, col] != '#' && matrix[row - 1, col] != '?' && matrix[row - 2, col] != '?')
                {
                    matrix[row - 1, col] = ' ';
                    matrix[row - 2, col] = ' ';
                }
                if (matrix[row + 1, col] != '#' && matrix[row + 1, col] != '?' && matrix[row + 2, col] != '?')
                {
                    matrix[row + 1, col] = ' ';
                    matrix[row + 2, col] = ' ';
                }
            }
            if (row - 1 == 0)
            {
                if (matrix[row + 1, col] != '#' && matrix[row + 1, col] != '?' && matrix[row + 2, col] != '?')
                {
                    matrix[row + 1, col] = ' ';
                    matrix[row + 2, col] = ' ';
                }
            }
            if (row + 1 == matrix.Rows - 1)
            {
                if (matrix[row - 1, col] != '#' && matrix[row - 1, col] != '?' && matrix[row - 2, col] != '?')
                {
                    matrix[row - 1, col] = ' ';
                    matrix[row - 2, col] = ' ';
                }
            }
        }
        else
        {
            matrix[row - 1, col] = ' ';
            matrix[row + 1, col] = ' ';
        }

        if (col != 0 && col != matrix.Cols - 1)
        {
            if (col - 2 >= 0 && col + 2 < matrix.Rows)
            {
                if (matrix[row, col - 1] != '#' && matrix[row, col - 1] != '?' && matrix[row, col - 2] != '?')
                {
                    matrix[row, col - 1] = ' ';
                    matrix[row, col - 2] = ' ';
                }
                if (matrix[row, col + 1] != '#' && matrix[row, col + 1] != '?' && matrix[row, col + 2] != '?')
                {
                    matrix[row, col + 1] = ' ';
                    matrix[row, col + 2] = ' ';
                }
            }
            if (col - 1 == 0)
            {
                if (matrix[row, col + 1] != '#' && matrix[row, col + 1] != '?' && matrix[row, col + 2] != '?')
                {
                    matrix[row, col + 1] = ' ';
                    matrix[row, col + 2] = ' ';
                }
            }
            if (col + 1 == matrix.Cols - 1)
            {
                if (matrix[row, col - 1] != '#' && matrix[row, col - 1] != '?' && matrix[row, col] != '?')
                {
                    matrix[row, col - 1] = ' ';
                    matrix[row, col - 2] = ' ';
                }
            }
        }
        else
        {
            matrix[row, col - 1] = ' ';
            matrix[row, col + 1] = ' ';
        }
        Collisions.EatenByEnemy(matrix, Enemy.enemyCoords, CrazyRusher.saveStartTime);

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (row == 1 && (col == 5 || col == 6 || col == 7 || col == 15 || col == 16 || col == 17))
                {
                    matrix[row, col] = ' ';
                    row = matrix.Rows - 2;
                    matrix[row, col] = playerChar;
                }

                if (row - 1 >= 0 && matrix[row - 1, col] != '#')
                {
                    matrix[row, col] = ' ';
                    row = row - 1;
                    matrix[row, col] = playerChar;
                }

            }

            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (row == matrix.Rows - 2 && (col == 5 || col == 6 || col == 7 || col == 15 || col == 16 || col == 17))
                {
                    matrix[row, col] = ' ';
                    row = 1;
                    matrix[row, col] = playerChar;
                }

                if (row + 1 < matrix.Rows && matrix[row + 1, col] != '#')
                {
                    matrix[row, col] = ' ';
                    row = row + 1;
                    matrix[row, col] = playerChar;
                }
            }

            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (col == 1 && (row == 5 || row == 6 || row == 7 || row == 15 || row == 16 || row == 17))
                {
                    matrix[row, col] = ' ';
                    col = matrix.Cols - 2;
                    matrix[row, col] = playerChar;
                }

                if (col - 1 >= 0 && matrix[row, col - 1] != '#')
                {
                    matrix[row, col] = ' ';
                    col = col - 1;
                    matrix[row, col] = playerChar;
                }
            }

            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (col == matrix.Cols - 2 && (row == 5 || row == 6 || row == 7 || row == 15 || row == 16 || row == 17))
                {
                    matrix[row, col] = ' ';
                    col = 1;
                    matrix[row, col] = playerChar;
                }

                if (col + 1 < matrix.Cols && matrix[row, col + 1] != '#')
                {
                    matrix[row, col] = ' ';
                    col = col + 1;
                    matrix[row, col] = playerChar;
                }
            }

            // configure shooting
            else if (pressedKey.Key == ConsoleKey.Spacebar)
            {
                Collisions.EnemyShot(matrix, Enemy.enemyCoords, CrazyRusher.saveStartTime);

                if (row - 2 >= 0 && row + 2 < matrix.Rows)
                {
                    if (matrix[row - 1, col] != '#')
                    {
                        matrix[row - 1, col] = '|';
                        matrix[row - 2, col] = '|';
                    }
                    if (matrix[row + 1, col] != '#')
                    {
                        matrix[row + 1, col] = '|';
                        matrix[row + 2, col] = '|';
                    }
                }
                if (row - 1 == 0)
                {
                    if (matrix[row + 1, col] != '#')
                    {
                        matrix[row + 1, col] = '|';
                        matrix[row + 2, col] = '|';
                    }
                }
                if (row + 1 == matrix.Rows - 1)
                {
                    if (matrix[row - 1, col] != '#')
                    {
                        matrix[row - 1, col] = '|';
                        matrix[row - 2, col] = '|';
                    }
                }

                if (col - 2 >= 0 && col + 2 < matrix.Cols)
                {
                    if (matrix[row, col - 1] != '#')
                    {
                        matrix[row, col - 1] = '-';
                        matrix[row, col - 2] = '-';
                    }
                    if (matrix[row, col + 1] != '#')
                    {
                        matrix[row, col + 1] = '-';
                        matrix[row, col + 2] = '-';
                    }
                }
                if (col - 1 == 0)
                {
                    if (matrix[row, col + 1] != '#')
                    {
                        matrix[row, col + 1] = '-';
                        matrix[row, col + 2] = '-';
                    }
                }
                if (col + 1 == matrix.Rows - 1)
                {
                    if (matrix[row, col - 1] != '#')
                    {
                        matrix[row, col - 1] = '-';
                        matrix[row, col - 2] = '-';
                    }
                }

            }
            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                Console.SetCursorPosition(24, 3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("            PAUSE            ");
                Console.ReadKey();
                Console.SetCursorPosition(27, 3);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Player: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(GameID.nick);
            }
        }

        return new int[] { row, col };
    }
}