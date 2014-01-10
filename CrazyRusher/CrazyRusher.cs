using System;

class CrazyRusher
{
    public static DateTime saveStartTime;
    static void Main()
    {
        Console.CursorVisible = false;
        GameField matrix = new GameField();
        saveStartTime = DateTime.Now;

        GameID.PrintGameName();
        GameField.DrawBorderLines();
        for (int i = 0; i < 7; i++)
        {
            GameField.EnemyCoordinates(matrix);

        }
        while (true)
        {
            DrawInitialGameField(matrix);
            Player.MovePlayer(matrix);

            Enemy.MoveEnemies(matrix);
            //Collisions.EatenByEnemy(matrix, Enemy.enemyCoords, CrazyRusher.saveStartTime);
            if (GameScores.gameOver == true)
            {
                break;
            }
        }
    }

    static void DrawInitialGameField(GameField matrix)
    {
        GameField.SetConsoleDimensions();
        GameField.SetMatrixContent(matrix);
        GameField.PlayerCoordinates(matrix);
        GameField.PrintMatrix(matrix);
    }


}
