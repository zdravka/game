using System;
using System.Collections.Generic;

class GameField
{
    private char[,] matrix;
    public static char wallChar = '#';
    static ConsoleColor wallColor = ConsoleColor.DarkCyan;
    
    const int WorldRows = 22;
    const int WorldCols = 22;

    
    public GameField(int rows = WorldRows, int cols = WorldCols)
    {
        this.matrix = new char[rows, cols];
    }

    public int Rows
    {
        get
        {
            return WorldRows;
        }
    }

    public int Cols
    {
        get
        {
            return WorldCols;
        }
    }

    public char this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    public static void SetMatrixContent(GameField matrix)
    {
        // smiley in unicode(\u263B)
        
        Console.ForegroundColor = wallColor;
        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                var gatewayEntries = new List<int>() { 5, 6, 7, 15, 16, 17 };
                Console.ForegroundColor = wallColor;
                // building walls, except gateways
                if (row == 0 || row == matrix.Rows - 1)
                {
                    if (!gatewayEntries.Contains(col))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                if (col == 0 || col == matrix.Cols - 1)
                {
                    if (!gatewayEntries.Contains(row))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                // building walls infront of the gateways
                if (row == 2 || row == matrix.Rows - 3)
                {
                    if (gatewayEntries.Contains(col))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                if (col == 2 || col == matrix.Cols - 3)
                {
                    if (gatewayEntries.Contains(row))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                // building inner walls
                var rowInnerWallsCoords = new List<int>() { 5, 6, 7, 8, 14, 15, 16, 17 };
                if (col == 7 || col == matrix.Cols - 7)
                {
                    if (rowInnerWallsCoords.Contains(row))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                var colInnerWallCoords = new List<int>() { 4, 5, 6, 7, 15, 16, 17, 18, 10, 11, 12 };
                if (row == 9 || row == matrix.Rows - 9)
                {
                    if (colInnerWallCoords.Contains(col))
                    {
                        matrix[row, col] = wallChar;
                    }
                }

                if (row == 6 || row == matrix.Rows - 6)
                {
                    if (col == 8 || col == 14)
                    {
                        matrix[row, col] = wallChar;
                    }
                }
            }
        }
    }

    public static void PlayerCoordinates(GameField matrix)
    {
        Player.SetPlayerCoordinates(matrix);
    }

    public static void EnemyCoordinates(GameField matrix)
    {
        Enemy.SetEnemyCoordinates(matrix);
    }

    public static void PrintMatrix(GameField matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            Console.SetCursorPosition(1, i + 5);
            for (int j = 0; j < matrix.Cols; j++)
            {
                if (matrix[i, j] == '#')
                {
                    Console.ForegroundColor = wallColor;
                    Console.Write("{0,2}", matrix[i, j]);
                }
                else if (matrix[i, j] == '\u263B' || matrix[i,j] == '-' || matrix[i,j] == '|')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0,2}", matrix[i, j]);
                }
                else
                {
                    Console.ForegroundColor = Enemy.enemyColor;
                    Console.Write("{0,2}", matrix[i, j]);

                }
            }
            Console.WriteLine();
        }
    }

    public static void DrawBorderLines()
    {
        char initialLines = '-';
        char borderChar = '|';
        ConsoleColor borderColor = ConsoleColor.DarkYellow;
        
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.SetCursorPosition(i, 4);
            Console.ForegroundColor = borderColor;
            Console.WriteLine(initialLines);
        }

        for (int i = 5; i < 28; i++)
        {
            Console.SetCursorPosition(47, i);
            Console.ForegroundColor = borderColor;
            Console.WriteLine(borderChar);
        }
    }

    public static void SetConsoleDimensions()
    {
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 75;
    }
}
  
