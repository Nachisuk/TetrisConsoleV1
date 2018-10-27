using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Console = Colorful.Console;

namespace TetrisConsoleV1
{
    class Interface
    {

        public static void Start()
        {

            setConsoleSize();

            Console.WriteLine(TetrisAsciStrings.getMainTitleString());
            Console.SetCursorPosition(Console.WindowWidth / 3, 10);
            Console.WriteLine("Press any button to continue");

            Console.ReadKey();

            MainMenu(MenuOptions.ZwrocOpcje());


        }


        public static void MainMenu(List<MainMenuOptions> listaopcji)
        {
            setConsoleSize();

            Console.WriteLine(TetrisAsciStrings.getMainTitleString());

            ConsoleKey key;
           //List<MainMenuOptions> listaopcji = MenuOptions.ZwrocOpcje();
            int i;
            int positionX = 30;
            Console.SetCursorPosition(positionX, Console.WindowHeight / 2);
            CurrentConsoleLineClear(positionX);

            for (i = 0; i < 3; i++)
            {
                if (i == 1) Console.ForegroundColor = Color.Red;
                else Console.ForegroundColor = Color.White;
                Console.Write(listaopcji[i].zwrocNazwe());
            }
            i = 1;
            int liczbaOpcji = listaopcji.Count;

            while (true)
            {
                            
                key = ConsoleKey.B;
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                }

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(positionX, Console.WindowHeight / 2);
                        CurrentConsoleLineClear(positionX);

                        for (int j = 2; j >= 0; j--)
                        {
                            if (j == 1) Console.ForegroundColor = Color.Red;
                            else Console.ForegroundColor = Color.White;

                            int z = (i - j) % liczbaOpcji;
                            if (z == (-1)) Console.Write(listaopcji[liczbaOpcji - 1].zwrocNazwe());
                            else if (z == (-2))
                            {
                                Console.Write(listaopcji[liczbaOpcji - 2].zwrocNazwe());
                                i = liczbaOpcji;
                            }
                            else Console.Write(listaopcji[z].zwrocNazwe());
                        }
                        i = (i - 1) % liczbaOpcji;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(positionX, Console.WindowHeight / 2);
                        CurrentConsoleLineClear(positionX);
                        for (int j = 0; j < 3; j++)
                        {
                            if (j == 1) Console.ForegroundColor = Color.Red;
                            else Console.ForegroundColor = Color.White;

                            Console.Write(listaopcji[(i + j) % liczbaOpcji].zwrocNazwe());
                        }
                        i = (i + 1) % liczbaOpcji;
                        break;
                    case ConsoleKey.Enter:
                        listaopcji[i].FunkcjaOpcji();
                        break;
                    case ConsoleKey.Escape:
                        MainMenu(MenuOptions.ZwrocOpcje());
                        break;
                }
            }
        }


        public static void GameOverScreen()
        {

        }

        //do czyszczenia linii
        public static void CurrentConsoleLineClear()
        {
            int currentline = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentline);
        }
        //do wyczyszczenia linii i powrotu na konkretne miejsce w osi X
        public static void CurrentConsoleLineClear(int currentXposition)
        {
            int currentline = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(currentXposition, currentline);
        }

        public static void setConsoleSize()
        {
            int heightOfWindow = 30;
            int widthOfWindow = 100;
            Console.SetWindowSize(widthOfWindow, heightOfWindow);
            Console.Clear();
        }
    }
}
