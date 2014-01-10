using System;
using System.Collections.Generic;


class Collisions
{
    public static void EnemyShot(GameField matrix, List<List<int>> enemyCoords, DateTime saveStartTime)
    {
        bool shot;
        int row = 0;
        int col = 0;
        for (int i = 0; i < enemyCoords.Count; i++)
        {
            row = enemyCoords[i][0];
            col = enemyCoords[i][1];


            if ((row == Player.row - 1 && col == Player.col) ||
             (row == Player.row - 2 && col == Player.col))
            {
               
                matrix[Enemy.enemyRow, Enemy.enemyCol] = ' ';
                enemyCoords.RemoveAt(i);
                shot = true;
                GameScores.CollisionScores(shot, saveStartTime);

            }
            else if ((row == Player.row + 1 && col == Player.col) ||
                (row == Player.row + 2 && col == Player.col))
            {
                matrix[Enemy.enemyRow, Enemy.enemyCol] = ' ';
                enemyCoords.RemoveAt(i);
                shot = true;
                GameScores.CollisionScores(shot, saveStartTime); 
            }
            else if ((col == Player.col + 1 && row == Player.row) ||
                (Enemy.enemyCol == Player.col + 2 && Enemy.enemyCol == Player.col))
            {
                matrix[Enemy.enemyRow, Enemy.enemyCol] = ' ';
                enemyCoords.RemoveAt(i);
                shot = true;
                GameScores.CollisionScores(shot, saveStartTime);
            }
            else if ((col == Player.col - 1 && row == Player.row) ||
                (col == Player.col - 2 && row == Player.row))
            {
                matrix[Enemy.enemyRow, Enemy.enemyCol] = ' ';
                enemyCoords.RemoveAt(i);
                shot = true;
                GameScores.CollisionScores(shot, saveStartTime);
            }
        }
    }

    public static void EatenByEnemy(GameField matrix, List<List<int>> enemyCoords, DateTime saveStartTime)
    {
        int row = 0;
        int col = 0;
        for (int i = 0; i < enemyCoords.Count; i++)
        {
            row = enemyCoords[i][0];
            col = enemyCoords[i][0];
            bool eaten = true;
            if (((Player.row + 1 == row) && (Player.col == col)) || 
               ((Player.row == row) && (Player.col + 1 == col)) ||
               ((Player.row - 1 == row) && (Player.col == col)) ||
               ((Player.row == row) && (Player.col - 1 == col)))
            {
                eaten = false;
                enemyCoords.RemoveAt(i);
                matrix[row, col] = ' ';
                GameScores.CollisionScores(eaten, saveStartTime);
                //GameScores.CollisionScores(false, saveStartTime);
            } 
        }
    }
}