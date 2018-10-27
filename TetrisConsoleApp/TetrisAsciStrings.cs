using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisConsoleV1
{
    class TetrisAsciStrings
    {

        public static string getMainTitleString()
        {
            string title = @"
                   _________  _______  _________  ________  ___  ________      
                  |\___   ___|\  ___ \|\___   ___|\   __  \|\  \|\   ____\     
                  \|___ \  \_\ \   __/\|___ \  \_\ \  \|\  \ \  \ \  \___|_    
                       \ \  \ \ \  \_|/__  \ \  \ \ \   _  _\ \  \ \_____  \   
                        \ \  \ \ \  \_|\ \  \ \  \ \ \  \\  \\ \  \|____|\  \  
                         \ \__\ \ \_______\  \ \__\ \ \__\\ _\\ \__\____\_\  \ 
                          \|__|  \|_______|   \|__|  \|__|\|__|\|__|\_________\
                                                                   \|_________|";
            return title;
        }

        public static string [] getPausePopUpString()
        {
            string [] title = { "■-■-■-■-■-■-■-■-■-■-■-■-■-■",
                                "■   ___  _  _ _ ___  _    ■",
                           /*   "■  | o \/ \| | |_ / / \   ■", */   "■  | o \\/ \\| | |_ / / \\   ■",
                                "■  |  _| o | U |/(_| o |  ■",
                                "■  |_| |_n_|___/___|_n_|  ■",
                                "■                         ■",
                                "■-■-■-■-■-■-■-■-■-■-■-■-■-■" };
            return title;
        }
    }
}
