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


        public static void PausePopUp()
        {
            int StartowyX = 0 + GameBoard.Position_X - 2;
            int StartowyY = 3 + GameBoard.Position_Y;
            string[] doWpisania = TetrisAsciStrings.getPausePopUpString();
            /*
            for (int lengthCount = 0; lengthCount <= GameBoard.TetrisBoardHeight; ++lengthCount)
            {
                Console.SetCursorPosition(0 + pos_x, lengthCount + pos_y);
                Console.Write("■");
                Console.SetCursorPosition((GameBoard.TetrisBoardHeight - 1) + pos_x, lengthCount + pos_y);
                Console.Write("■");
            }
            */

            Console.SetCursorPosition(StartowyX, StartowyY);

            for(int hightCount = 0; hightCount<doWpisania.Length; hightCount++)
            {
                Console.SetCursorPosition(StartowyX, StartowyY+hightCount);
                /*
                for (int widthCount = 0; widthCount <doWpisania[hightCount].Length; widthCount++)
                {
                    Console.Write(doWpisania[hightCount][widthCount]);
                }
                */
                Console.Write(doWpisania[hightCount]);
            }

            


        }

        public static void PausePopUpOff()
        {
            int StartowyX = 0 + GameBoard.Position_X - 2;
            int StartowyY = 3 + GameBoard.Position_Y;
            //int tmp_y = 3;
            string [] okienko = TetrisAsciStrings.getPausePopUpString();

            Console.SetCursorPosition(StartowyX, StartowyY);
            for(int tmp_y = StartowyY; tmp_y < StartowyY+ okienko.Length; tmp_y++)
            {
                Console.SetCursorPosition(StartowyX, tmp_y);

                for (int widthCount = 0; widthCount <= okienko[tmp_y-StartowyY].Length; widthCount++)
                {
                    if (Console.CursorLeft == GameBoard.Position_X || Console.CursorLeft == GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2)
                        Console.Write("*");

                    else if (Console.CursorLeft > GameBoard.Position_X && Console.CursorLeft < GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2)
                    {
                        Console.Write(" ");
                        widthCount++;
                        for (int j = 0; j < GameBoard.TetrisBoardWidth; j++)
                        {
                            Console.SetCursorPosition(2 * j + GameBoard.Position_X + 2, tmp_y);
                            if (GameBoard.grid[tmp_y, j] == 1 || GameBoard.lokacjaOstatniegoTetrisaGrid[tmp_y, j] == 1)
                            {
                                Console.SetCursorPosition(2 * j + GameBoard.Position_X + 2, tmp_y);
                                if (GameBoard.tetrisColorGrid[tmp_y, j] < 1 || GameBoard.tetrisColorGrid[tmp_y, j] > 8)
                                    Console.ForegroundColor = GameBoard.WriteColor(GameBoard.aktualnyKolor);
                                else
                                    Console.ForegroundColor = GameBoard.WriteColor(GameBoard.tetrisColorGrid[tmp_y, j]);

                                Console.Write("■ ");
                            }
                            else
                            {
                                Console.Write("  ");
                            }
                            widthCount += 2;
                        }

                        Console.ForegroundColor = Color.White;
                        Console.SetCursorPosition(GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2, tmp_y);
                    }

                    else
                        Console.Write(" ");

                }
            }

            /*
            for (int widthCount = 0; widthCount <= (GameBoard.TetrisBoardWidth + 2) * 2 + 3; widthCount++)
            {
                if (Console.CursorLeft == GameBoard.Position_X || Console.CursorLeft == GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2)
                    Console.Write("*");

                else if (Console.CursorLeft > GameBoard.Position_X && Console.CursorLeft < GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2)
                {
                    Console.Write(" ");
                    for (int j = 0; j < GameBoard.TetrisBoardWidth; j++)
                    {
                        Console.SetCursorPosition(2 * j + GameBoard.Position_X + 2, tmp_y);
                        if (GameBoard.grid[tmp_y, j] == 1 || GameBoard.lokacjaOstatniegoTetrisaGrid[tmp_y, j] == 1)
                        {
                            Console.SetCursorPosition(2 * j + GameBoard.Position_X + 2, tmp_y);
                            if (GameBoard.tetrisColorGrid[tmp_y, j] < 1 || GameBoard.tetrisColorGrid[tmp_y, j] > 8)
                                Console.ForegroundColor = GameBoard.WriteColor(GameBoard.aktualnyKolor);
                            else
                                Console.ForegroundColor = GameBoard.WriteColor(GameBoard.tetrisColorGrid[tmp_y, j]);

                            Console.Write("■ ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.ForegroundColor = Color.White;
                    Console.SetCursorPosition(GameBoard.Position_X + (GameBoard.TetrisBoardWidth + 1) * 2, tmp_y);
                }

                else
                    Console.Write(" ");
                
            }
            */


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
