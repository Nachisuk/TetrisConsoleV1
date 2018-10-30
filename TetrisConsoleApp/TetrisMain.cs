using System;
using System.Runtime.InteropServices;

namespace TetrisConsoleV1
{
    class TetrisMain
    {
        //To poniżej gdybyśmy chciei jakos wpleść zapisywanie scoreboarda do pliku przy wylączniu consoli
        /*
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            switch (sig)
            {
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                default:
                    //Tutaj najprawdopodobniej kod metody zapisujacej
                    return true;
            }
        }
        */





        static void Main(string[] args)
        {
            //Te dwie linijki poniżej do tego co wyżej
            //_handler += new EventHandler(Handler);
           // SetConsoleCtrlHandler(_handler, true);

            GameBoard.ConsoleInitialize();
            Interface.Start();
            //a
            //Kombinacje alpejskie
            //gameboard.Uruchom();
            //as
            ///Console.Read();
        }

        
    }
}
