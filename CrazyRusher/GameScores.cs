using System;
using System.Text;
using System.IO;

class GameScores
{

    public static int scores = 0;
    public static int lives = 5;
    public static int enemiesLeft = 7;
    public static bool gameOver = false;


    //shooting bad guys scores = true, eaten by bad guys = false;  CALL FROM COLLISION
    public static void CollisionScores(bool ShootedOREaten, DateTime saveStartTime) // saveStartTime is needed here to calculate the elapsed time when the game is over
    {
        if (ShootedOREaten == true)
        {
            scores += 1000;
            enemiesLeft--;
            DateTime saveFinishTime = DateTime.Now;
            int elapsed = CalculateTimeElapsed(saveStartTime, saveFinishTime);
            Console.ForegroundColor = ConsoleColor.White; 
            Console.SetCursorPosition(49, 7);
            Console.Write("Enemies left: {0}", enemiesLeft);
            Console.SetCursorPosition(49, 13);
            Console.Write("Score: {0}", Math.Abs(scores + (scores-elapsed)));

            if (enemiesLeft ==0)
            {
                saveFinishTime = DateTime.Now;
                YouWon();
                elapsed = CalculateTimeElapsed(saveStartTime, saveFinishTime);
                WriteHiScoresHistory(scores, elapsed);
                Console.ReadKey();
                return;
            }
        }
        else
        {
            enemiesLeft--;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(49, 7);
            Console.Write("Enemies left: {0}", enemiesLeft);
            lives--;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(49, 10);
            Console.Write("Hits to death: {0}", lives);
        }

        if (enemiesLeft == 0)
        {
            DateTime saveFinishTime = DateTime.Now;
            YouWon();
            int elapsed = CalculateTimeElapsed(saveStartTime, saveFinishTime);
            WriteHiScoresHistory(scores, elapsed);
            Console.ReadKey();
            return;
        }

        if (lives == 0)
        {
            DateTime saveFinishTime = DateTime.Now;
            GameOver();
            int elapsed = CalculateTimeElapsed(saveStartTime, saveFinishTime);
            WriteHiScoresHistory(scores, elapsed);
            Console.ReadKey();
            return;
        }
    }

    static void GameOver()
    {
        gameOver = true;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2);
        Console.WriteLine("GAME OVER");
    }

    static void YouWon()
    {
        gameOver = true;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(18, Console.WindowHeight / 2);
        Console.Write("CONGRATULATIONS! YOU WON!");
    }

    static int CalculateTimeElapsed(DateTime saveStartTime, DateTime saveFinishTime)
    {
        int startTime = saveStartTime.Second;
        int finishTime = saveFinishTime.Second;
        int elapsed = finishTime - startTime;
        return elapsed;
    }

    static void WriteHiScoresHistory(int scores, int elapsed)
    {
        Console.SetCursorPosition(18, 0);
        Console.CursorVisible = true;
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        string path = @"..\..\bin\Debug\Scores.txt";

        StreamWriter hiScores = File.AppendText(path);
        int scoresInFile = Math.Abs(scores + scores - elapsed);
        string strElapsed = Math.Abs(elapsed).ToString();
        string strScoresInFile = scoresInFile.ToString();

        using (hiScores)
        {
            Console.WriteLine();
            hiScores.WriteLine("{0} {1} {2}", name.PadRight(10), strScoresInFile.PadLeft(10), strElapsed.PadLeft(10));
        }
        Console.Clear();
        string line = "";
        using (StreamReader displayHiScores = File.OpenText(path))
        {
            while ((line = displayHiScores.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
