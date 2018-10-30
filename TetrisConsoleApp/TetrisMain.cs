using System;
using System.Runtime.InteropServices;

namespace TetrisConsoleV1
{
    class TetrisMain
    {

        static void Main(string[] args)
        {
            GameBoard.ConsoleInitialize();
            Interface.Start();
        }

        
    }
}
