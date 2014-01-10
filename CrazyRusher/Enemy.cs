using System;
using System.Collections.Generic;
using System.Linq;

class Enemy
{
    public static ConsoleColor enemyColor = ConsoleColor.Magenta;
    static Random generator = new Random();
    public static int enemyRow;
    public static int enemyCol;

    static char enemyChar = '?';
    public static List<List<int>> enemyCoords = new List<List<int>>();

    public static void SetEnemyCoordinates(GameField matrix)
    {
        enemyRow = generator.Next(2, 21);
        enemyCol = generator.Next(1,21);
        if (matrix[enemyRow, enemyCol] != '#' && matrix[enemyRow, enemyCol] != Player.playerChar)
        {
            matrix[enemyRow, enemyCol] = enemyChar;
        }

        enemyCoords.Add((new int[] { enemyRow, enemyCol }).ToList());
    }
    public static int listiIndex =0;
    public static void MoveEnemies(GameField matrix)
    {
        for (int i = 0; i < enemyCoords.Count; i++)
        {
            int direction = generator.Next(1, 5); // 1 - left; 2 - right; 3 - up; 4 - down;
            enemyRow = enemyCoords[i][0];
            enemyCol = enemyCoords[i][1];
            listiIndex = i;
            if (direction == 1)
            {
                if (matrix[enemyRow, enemyCol - 1] != GameField.wallChar && enemyCol - 1 >= 1)
                {
                   matrix[enemyRow, enemyCol] = ' ';
                   matrix[enemyRow, enemyCol - 1] = enemyChar;
                   enemyCoords[i][1] = enemyCol - 1;
                }
            }
            else if (direction == 2)
            {
                if (matrix[enemyRow, enemyCol + 1] != GameField.wallChar && enemyCol + 1 < matrix.Cols - 1)
                {
                   matrix[enemyRow, enemyCol] = ' ';
                   matrix[enemyRow, enemyCol + 1] = enemyChar;
                   enemyCoords[i][1] = enemyCol + 1;
                }
            }
            else if (direction == 3)
            {
                if (matrix[enemyRow - 1, enemyCol] != GameField.wallChar && enemyRow - 1 >= 1)
                {
                   matrix[enemyRow, enemyCol] = ' ';
                   matrix[enemyRow - 1, enemyCol] = enemyChar;
                   enemyCoords[i][0] = enemyRow - 1;
                }
            }
            else if (direction == 4)
            {
                if (enemyRow + 1 < matrix.Rows - 1 && matrix[enemyRow + 1, enemyCol] != GameField.wallChar)
                {
                    matrix[enemyRow, enemyCol] = ' ';
                    matrix[enemyRow + 1, enemyCol] = enemyChar;
                    enemyCoords[i][0] = enemyRow + 1;
                }
            }

        }  
    }

}
