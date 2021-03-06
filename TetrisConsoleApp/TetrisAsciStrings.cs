﻿using System;
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

        public static string[] GetGameOver()
        {

            
            
                string[] title = {  "■-■-■-■-■-■-■-■-■-■-■-■-■-■",
                                    "■  _  _ _  _  _ _ ___ __  ■",
                                /*  "■ | |/// \| \| | | __/ _| ■",    */ "■ | |/// \\| \\| | | __/ _| ■",
                                /*  "■ |  (( o | \\ | | _( (_  ■",    */ "■ |  (( o | \\\\ | | _( (_  ■",
                                /*  "■ |_|\\\_/|_|\_|_|___\__| ■",    */  "■ |_|\\\\\\_/|_|\\_|_|___\\__| ■",
                                    "■            __  _____ __ ■",
                                 /* "■           / _|| o \ V / ■",    */  "■           / _|| o \\ V / ■",
                                 /* "■          ( |_n|   /\ /  ■",    */  "■          ( |_n|   /\\ /  ■",
                                 /* "■           \__||_|\\|_|  ■",    */  "■           \\__||_|\\\\|_|  ■",
                                    "■                         ■",
                                    "■                         ■",
                                    "■  Restart  Podsumowanie  ■",
                                    "■                         ■",
                                    "■-■-■-■-■-■-■-■-■-■-■-■-■-■" };
                return title;
            
        }

        public static string getPodsumowanieString()
        {
            string podsumowanie = @"
                        ___          _                                              _      
                       / _ \___   __| |___ _   _ _ __ ___   _____      ____ _ _ __ (_) ___ 
                      / /_)/ _ \ / _` / __| | | | '_ ` _ \ / _ \ \ /\ / / _` | '_ \| |/ _ \
                     / ___/ (_) | (_| \__ \ |_| | | | | | | (_) \ V  V / (_| | | | | |  __/
                     \/    \___/ \__,_|___/\__,_|_| |_| |_|\___/ \_/\_/ \__,_|_| |_|_|\___| ";
            return podsumowanie;
        }

        public static string getPoziomString()
        {
            string podsumowanie = @"
                  ___  ____ ___  _ ____ _  _ 
                  |__] |  |   /  | |  | |\/|. 
                  |    |__|  /__ | |__| |  |.";
            return podsumowanie;
        }

        public static string getPunktyString()
        {
            string podsumowanie = @"
                  ___  _  _ _  _ _  _ ___ _   _ 
                  |__] |  | |\ | |_/   |   \_/  .
                  |    |__| | \| | \_  |    |   .
                               ";
            return podsumowanie;
        }

        public static string getLinieString()
        {
            string podsumowanie = @"
                  _    _ _  _ _ ____ 
                  |    | |\ | | |___ .
                  |___ | | \| | |___ .
                    ";
            return podsumowanie;
        }
        public static string space1()
        {
            string space ="           ";
            return space;
        }
    }
}
