using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisConsoleV1
{
    public interface MainMenuOptions
    {
       void FunkcjaOpcji();
       string zwrocNazwe();
    }

    public class MainMenu_ClassicTet : MainMenuOptions
    {
        public string nazwa = "Klasyczny Tetris ";
        public void FunkcjaOpcji()
        {
            Console.Clear();
            GameBoard gameboard = new GameBoard();
            gameboard.Initlialize();
            gameboard.Uruchom();
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class MainMenu_Scoreboard : MainMenuOptions
    {
        public string nazwa = "Tablice wyników ";
        public void FunkcjaOpcji()
        {
            
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class MainMenu_ExitGame : MainMenuOptions
    {
        public string nazwa = "Wyjdz z gry ";
        public void FunkcjaOpcji()
        {
            Environment.Exit(0);
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class MainMenu_Statystyki : MainMenuOptions
    {
        public string nazwa = "Statystyki ";
        public void FunkcjaOpcji()
        {
            
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }
    public static class MenuOptions
    {

        public static List<MainMenuOptions> ZwrocOpcje()
        {
            List<MainMenuOptions> listaopcji = new List<MainMenuOptions>();
            listaopcji.Add(new MainMenu_ClassicTet());
            listaopcji.Add(new MainMenu_Scoreboard());
            listaopcji.Add(new MainMenu_Statystyki());
            listaopcji.Add(new MainMenu_ExitGame());

            return listaopcji;
        }
    }
    
}
