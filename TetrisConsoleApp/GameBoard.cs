﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TetrisConsoleV1
{
    class GameBoard
    {
        //Zmienne przedastawiające pole gry, druga zmienna pokazuje pola "zajęte" przez wcześniejsze klocki
        public static int[,] grid;
        public static int[,] lokacjaOstatniegoTetrisaGrid;
        public static int[,] tetrisColorGrid;
		//pisze testowy komentarz
        //Zmienne stoperów potrzebne do kontroli opadania, odczekania wciśnięcia przyisku itp.
        public static Stopwatch timer;
        public static Stopwatch dropTimer;
        public static Stopwatch inputTimer;
        public static int dropTime, dropRate, inputTime;

        //Zmienna mówiąca czy dany klocek tetrisa już opadł
        public static bool czyOpadł;

        //zmienna przesuwają miejsce wypisywania granic tetrisa
        static int Position_X = 30;
        static int Position_Y = 0;

        //zmienne zmieniające wielkość tetrisa
        public static int TetrisBoardHeight = 23;
        public static int TetrisBoardWidth = 10;

        //zmmienne do sterowania przyciskami
        public static ConsoleKeyInfo key;
        public static bool czyNacisnieto = false;
        public static bool czyCosZLewej = false;
        public static bool czyCosZPrawej = false;
        bool isLineCleared;

        //zmmienne dotyczące klocków tetrisa
        public static Tetrimo tetris;
        public static Tetrimo następnyTetris;

        //zmienna do losowanek
        public static Random rnd;

        public static int aktualnyKolor;
        public static int nastepnyKolor;

        public static string element;

        //zmienne punktów,linni,combo

        public static int punkty, wyczyszczoneLinie, combo, poziom;

        //zmienna okreslająca czy to game over
        public static bool czyGameOver;
        public static bool czyZapauzowane;


        //Podstawowa funkcja rysująca granice Tetrisa, jak na razie w takiej postaci
        public static void drawBorder()
        {
            for (int lengthCount = 0; lengthCount <= TetrisBoardHeight; ++lengthCount)
            {
                Console.SetCursorPosition(0+Position_X, lengthCount+Position_Y);
                Console.Write("*");
                Console.SetCursorPosition((TetrisBoardHeight-1)+Position_X, lengthCount+Position_Y);
                Console.Write("*");
            }
            Console.SetCursorPosition(0+Position_X, (TetrisBoardHeight+1)+Position_Y);
            for (int widthCount = 0; widthCount <= TetrisBoardWidth; widthCount++)
            {
                Console.Write("*-");
            }
            Console.Write("*");

            Console.SetCursorPosition(Position_X * 2, 2);
            Console.Write("Poziom:");

            Console.SetCursorPosition(Position_X * 2, 4);
            Console.Write("Punkty:");

            Console.SetCursorPosition(Position_X*2, 6);
            Console.Write("Wyczyszczone linie:");

            Console.SetCursorPosition(Position_X * 2, 8);
            Console.Write("Kombo:");

            Console.SetCursorPosition(Position_X * 2, 12);
            Console.Write("Następny kształt:");


        }

        public static void Rysuj()
        {
            for (int i = 0; i < TetrisBoardHeight+1; i++)  
            {
                for (int j = 0; j < TetrisBoardWidth; j++)
                {
                    Console.SetCursorPosition(2 * j+Position_X+2, i);
                    if (grid[i, j] == 1 || lokacjaOstatniegoTetrisaGrid[i, j] == 1)
                    {
                        Console.SetCursorPosition(2 * j+ Position_X + 2, i);
                        if(tetrisColorGrid[i, j] < 1 || tetrisColorGrid[i, j] > 8) 
                            Console.ForegroundColor = Color(aktualnyKolor);
                        else
                            Console.ForegroundColor = Color(tetrisColorGrid[i, j]);

                        Console.Write("■");
                        //Console.ResetColor();
                    }
                    else
                    {
                        //Console.SetCursorPosition(2 * j + Position_X + 2, i);
                        Console.Write(" ");
                    }
                }
            }
        }
        public void RysujNastępnyKlocek(int[,] kształt)
        {
            WyczyscPrzedNastepnymKlockiem();
            Console.SetCursorPosition(Position_X * 2, 14);
            Console.ForegroundColor = Color(nastepnyKolor);
            int z = 0;
            for(int i =0; i< kształt.GetLength(0); i++)
            {
                for(int j = 0; j<kształt.GetLength(1)*2;j++)
                {
                    Console.SetCursorPosition(Position_X * 2+j, i+14);
                    if (kształt[i, j/2] == 1)
                        Console.Write("■");
                    else
                        Console.Write(" ");
                    j++;
                    Console.SetCursorPosition(Position_X * 2 + j, i + 14);
                    Console.Write(" ");
                }
            }

        }

        public void WyczyscPrzedNastepnymKlockiem()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4 * 2; j++)
                {
                    Console.SetCursorPosition(Position_X * 2 + j, i + 14);
                    Console.Write(" ");
                }
            }
        }


        public static void Sterowanie2()
        {
            ConsoleKey choice;
            if(Console.KeyAvailable)
            {
                 choice = Console.ReadKey(true).Key;
            }
            else
            {
                
                return;
            }

            switch(choice)
            {
                case ConsoleKey.LeftArrow:
                    if(!tetris.czyJestCosZLewa())
                    {
                        for (int i = 0; i < 4; i++)
                        {

                            tetris.lokacja[i][1] -= 1;

                        }
                        tetris.Aktualizuj();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(!tetris.czyJestCosZPrawa())
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tetris.lokacja[i][1] += 1;
                        }
                        tetris.Aktualizuj();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    tetris.Opadaj();
                    break;
                case ConsoleKey.UpArrow:
                    while (tetris.czyJestCosPonizej() != true)
                    {
                        tetris.Opadaj();
                    }
                    break;
                case ConsoleKey.Spacebar:
                    tetris.Obroc();
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    GameBoard gameboard = new GameBoard();
                    gameboard.Initlialize();
                    gameboard.Uruchom();
                    break;
                case ConsoleKey.P:
                    if (!czyZapauzowane) czyZapauzowane = true;
                    break;
                case ConsoleKey.Escape:
                    Interface.MainMenu(MenuOptions.ZwrocOpcje());
                    break;
            }
        }

        public void WyczyscLinie()
        {
            int combo = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Position_X * 2 + 6, 8);
            Console.Write(combo.ToString());
            Console.SetCursorPosition(Position_X * 2 + 8, 2);
            Console.Write(poziom.ToString());

            Console.SetCursorPosition(Position_X * 2 + 8, 4);
            Console.Write(punkty.ToString());

            Console.SetCursorPosition(Position_X * 2 + 20, 6);
            Console.Write(wyczyszczoneLinie.ToString());
            for (int i = 0; i < TetrisBoardHeight + 1; i++)
            {
                int j;
                for ( j = 0; j < TetrisBoardWidth; j++)
                {
                    if (lokacjaOstatniegoTetrisaGrid[i, j] == 0) break;
                }

                if (j == 10)
                {
                    wyczyszczoneLinie++;
                    combo++;
                    isLineCleared = true;
                    //TODO lines clear + combo
                    //czyszczenie pełnej linii
                    for (j = 0; j < 10; j++)
                    {
                        lokacjaOstatniegoTetrisaGrid[i, j] = 0;
                    }

                    //tworzenie nowego gridu po usunięciu linii
                    int[,] nowaTablicaZrzuconychTetrisow = new int[TetrisBoardHeight + 1, TetrisBoardWidth];
                    int[,] nowaTablicaKolorów = new int[TetrisBoardHeight + 1, TetrisBoardWidth];
                    //przesuwanie w dół wszystkich elementów po usunięciu linii
                    for (int z = 1; z < i; z++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            nowaTablicaZrzuconychTetrisow[z + 1, x] = lokacjaOstatniegoTetrisaGrid[z, x];
                            nowaTablicaKolorów[z + 1, x] = tetrisColorGrid[z, x];
                            tetrisColorGrid[z, x] = 10;
                            lokacjaOstatniegoTetrisaGrid[z, x] = 0;
                        }
                    }

                    //przekazanie przesuniętych elementów do aktualnej tablicy przechowującej nasze klocki

                    for (int z = 0; z < TetrisBoardHeight + 1; z++)
                    {
                        for (int x = 0; x < TetrisBoardWidth; x++)
                        {
                            if (nowaTablicaZrzuconychTetrisow[z, x] == 1) 
                            {
                                lokacjaOstatniegoTetrisaGrid[z, x] = 1;
                            }

                            if (lokacjaOstatniegoTetrisaGrid[z, x] == 1 && !(tetrisColorGrid[z, x] == 10))
                            {
                                nowaTablicaKolorów[z, x] = tetrisColorGrid[z, x];

                            }
                        }
                    }
                /*
                    for (int z = 0; z < TetrisBoardHeight + 1; z++)
                    {
                        for (int x = 0; x < TetrisBoardWidth; x++)
                        {
                            if(lokacjaOstatniegoTetrisaGrid[z,x] == 1 && !(tetrisColorGrid[z,x] == 10))
                            {
                                nowaTablicaKolorów[z, x] = tetrisColorGrid[z, x];

                            }
                        }
                    }
                    */
                    tetrisColorGrid = nowaTablicaKolorów;
                    Rysuj();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Position_X * 2 + 6, 8);
                    Console.Write(combo.ToString());
                }
            }

            if (combo == 1)
                punkty += 30 * poziom;
            else if (combo == 2)
                punkty += 60 * poziom;
            else if (combo == 3)
                punkty += 180 * poziom;
            else if (combo == 4)
                punkty += 250 * poziom;
            else if (combo > 4)
                punkty += 350 * poziom;
            
            if (wyczyszczoneLinie % 10 == 0 && wyczyszczoneLinie > 0 && isLineCleared)
            {
                poziom++;
                if (poziom <= 10) dropRate = dropRate - 20;
                isLineCleared = false;
            }

            if(combo > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Position_X * 2+8, 2);
                Console.Write(poziom.ToString());

                Console.SetCursorPosition(Position_X * 2+8, 4);
                Console.Write(punkty.ToString());

                Console.SetCursorPosition(Position_X * 2+20, 6);
                Console.Write(wyczyszczoneLinie.ToString());

            }
            
        }
        //Zmiana wysokości i szerkokości okienka konsoli
        public static void setConsoleWindowSize()
        {
            int heightOfWindow = 30;
            int widthOfWindow =100;

            Console.SetWindowSize(widthOfWindow, heightOfWindow);

        }

        //TODO
        public void Initlialize()
        {
            InitializeVariables();
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.Title = "Tetris";

            setConsoleWindowSize();
            drawBorder();

            timer.Start();
            dropTimer.Start();
        }

        public static void ConsoleInitialize()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.Title = "Tetris";

            setConsoleWindowSize();
        }

        public void InitializeVariables()
        {
            grid = new int[TetrisBoardHeight+1, TetrisBoardWidth];
            lokacjaOstatniegoTetrisaGrid = new int[TetrisBoardHeight+1, TetrisBoardWidth];
            tetrisColorGrid = new int[TetrisBoardHeight + 1, TetrisBoardWidth];
            timer = new Stopwatch();
            dropTimer = new Stopwatch();
            inputTimer = new Stopwatch();
            dropRate = 300;
            inputTime = 10;
            czyOpadł = false;
            czyNacisnieto = false;
            Random rnd = new Random();
            aktualnyKolor = rnd.Next(1, 7);
            nastepnyKolor = rnd.Next(1, 7);
            czyCosZLewej = false;
            punkty = 0; wyczyszczoneLinie = 0; combo = 0;
            poziom = 1;
            element = Encoding.ASCII.GetString(new byte[] { 65 });
            bool isLineCleared = false;
            czyZapauzowane = false;
            czyGameOver = false;
        }

        public static ConsoleColor Color(int rodzaj)
        {           
            switch (rodzaj)
            {
                case 1:
                    return ConsoleColor.Cyan;
                case 2:
                    return ConsoleColor.Blue;
                case 3:
                    return ConsoleColor.Yellow;
                case 4:
                    return ConsoleColor.Green;
                case 5:
                    return ConsoleColor.Magenta;
                case 6:
                    return ConsoleColor.Red;
                case 7:
                    return ConsoleColor.DarkGreen;
                default:
                    return ConsoleColor.Black;
            }
        }

        public void Uruchom()
        {
            Console.ForegroundColor = Color(aktualnyKolor);
            tetris = new Tetrimo();
            następnyTetris = new Tetrimo();
            tetris.Stwórz();
            RysujNastępnyKlocek(następnyTetris.getKształt());


            while (true)
            {               
                dropTime = (int)dropTimer.ElapsedMilliseconds;
                if(dropTime > dropRate)
                {
                    dropTime = 0;
                    dropTimer.Restart();
                    tetris.Opadaj();
                }

                if(czyOpadł)
                {
                    if (tetris.CzyWystaje())
                    {
                        czyGameOver = true;
                    }

                    else
                    {
                        Random rnd = new Random();

                        Console.ForegroundColor = Color(aktualnyKolor);

                        tetris = następnyTetris;
                        następnyTetris = new Tetrimo();

                        aktualnyKolor = nastepnyKolor;
                        nastepnyKolor = rnd.Next(1, 7);

                        RysujNastępnyKlocek(następnyTetris.getKształt());

                        if (!tetris.Stwórz())
                            czyGameOver = true;
                        czyOpadł = false;
                    } 
                    
                    if(czyGameOver == true)
                    {
                        //if Game Over to jakies dzialania, pewnie GameOver() - jakies dopisywanie do scoreboarda itd. a potem reset i wznowienie albo powrot do menu
                       // break;
                    }
                }
                if(czyZapauzowane)
                {
                    while(czyZapauzowane)
                    {
                        ConsoleKey choice;
                        if (Console.KeyAvailable)
                        {
                            choice = Console.ReadKey(true).Key;
                            if (choice == ConsoleKey.P)
                            {
                                czyZapauzowane = false;
                            }
                        }
                        
                    }
                }

                Sterowanie2();
                WyczyscLinie();

            }
        }


    }
}