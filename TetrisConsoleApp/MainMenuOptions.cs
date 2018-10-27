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
        public string nazwa = "      Graj       ";
        public void FunkcjaOpcji()
        {
            Interface.MainMenu(GameMenuOptions.ZwrocTryby());
           
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class MainMenu_Scoreboard : MainMenuOptions
    {
        public string nazwa = " Tablice wyników ";
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
        public string nazwa = "   Wyjdz z gry   ";
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
        public string nazwa = "   Statystyki    ";
        public void FunkcjaOpcji()
        {
            
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }
    public class GameMode_Marathon : MainMenuOptions
    {
        public string nazwa = "  Maraton ";
        public void FunkcjaOpcji()
        {
            GameMenuOptions.GameModeStart(nazwa);
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }
    public class GameMode_Endless : MainMenuOptions
    {
        public string nazwa = "  Endless ";
        public void FunkcjaOpcji()
        {
            GameMenuOptions.GameModeStart(nazwa);
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class GameMode_Ultra : MainMenuOptions
    {
        public string nazwa = "   Ultra  ";
        public void FunkcjaOpcji()
        {
            GameMenuOptions.GameModeStart(nazwa);
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class GameMode_LandSlide : MainMenuOptions
    {
        public string nazwa = " LandSlide ";
        public void FunkcjaOpcji()
        {
            GameMenuOptions.GameModeStart(nazwa);
        }

        public string zwrocNazwe()
        {
            return this.nazwa;
        }
    }

    public class GameMode_Haunted : MainMenuOptions
    {
        public string nazwa = "  Haunted  ";
        public void FunkcjaOpcji()
        {
            GameMenuOptions.GameModeStart(nazwa);
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

    public static class GameMenuOptions
    {
        public static List<MainMenuOptions> ZwrocTryby()
        {
            List<MainMenuOptions> listaopcji = new List<MainMenuOptions>();
            listaopcji.Add(new GameMode_Marathon());
            listaopcji.Add(new GameMode_Endless());
            listaopcji.Add(new GameMode_Ultra());
            listaopcji.Add(new GameMode_LandSlide());
            listaopcji.Add(new GameMode_Haunted());

            return listaopcji;
        }

        public static void GameModeStart(String mode)
        {
            Console.Clear();
            GameBoard gameboard = new GameBoard();
            gameboard.Initlialize(mode);
            gameboard.Uruchom();
        }
    }

}
