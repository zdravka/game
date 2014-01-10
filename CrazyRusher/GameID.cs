using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class GameID
{
    private static string name = GetPlayerName();
    public static string nick = name;
    private static void PrintInitialPicture()
    {
        var sb = new StringBuilder();

        using (StreamReader reader = new StreamReader("welcScreenOuter.txt"))
        {
            sb.Append(reader.ReadToEnd());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sb.ToString());
            sb.Clear();
        }

        using (StreamReader reader = new StreamReader("welcScreen.txt"))
        {
            sb.Append(reader.ReadToEnd());
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sb.ToString());
        }
    }

    public static string GetPlayerName()
    {
        using (StreamReader reader = new StreamReader("plot.txt"))
        {
            int ch = int.MaxValue;
            int inline = 4;
            int row = 5;
            Console.SetCursorPosition(inline, row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            while (ch > 0 )
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    break;
                }
               
                ch = reader.Read();
                if (ch == 10)
                {
                    row+=2;
                    inline+=2;
                    Console.WriteLine();
                    Console.SetCursorPosition(inline, row);
                }
                else
                {
                    Console.Write((char)ch);
                    Thread.Sleep(30);
                }
                
            }
            Console.ReadKey();
            Console.Clear();
        }

        PrintInitialPicture();
       
        GameField.SetConsoleDimensions();
        GameField.DrawBorderLines();

        Console.SetCursorPosition(7, 25);
        Console.Write("Please enter your name: ");
        string playerName = "";

        
        while (true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                playerName = Console.ReadLine();
                if (playerName.Length > 14 || playerName.Length < 6)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.SetCursorPosition(7, 26);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press any key to start the game... ");
                Console.ReadKey();

                return playerName;

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.SetCursorPosition(7, 26);
                Console.WriteLine("Please input name between 6 - 14 chars!");
                Console.ReadKey();
                Console.Clear();
                
                PrintInitialPicture();
                GameField.DrawBorderLines();
                Console.SetCursorPosition(7, 25);
                Console.Write("Please enter your name: ");
                
            } 
        }
    }

    public static void PrintGameName()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Gray;
        using (StreamReader reader = new StreamReader("inGameID.txt"))
        {
            var sb = new StringBuilder();
            sb.Append(reader.ReadToEnd());
            Console.WriteLine(sb.ToString());
        }
        
        Console.SetCursorPosition(27, 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Player: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(name);
    }
}
