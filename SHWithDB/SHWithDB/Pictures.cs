using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHWithDB
{
    class Pictures
    {
        public static Image setStartPict (string discipline)
        {
            if (discipline == "Dota 2")
            {
                return Properties.Resources._1509653772_dota_2_logo_pictures_desktop_hd_wallpaper_640x480_2149492;
            } else if (discipline == "CS:GO")
            {
                return Properties.Resources.SpicyImprobableCooter_size_restricted;
            }
            else if (discipline == "LOL")
            {
                return Properties.Resources.lol;
            }
            else if (discipline == "Valorant")
            {
                return Properties.Resources.tenor;
            }
            else if (discipline == "Smite")
            {
                return null;
            }
            else if (discipline == "COD")
            {
                return Properties.Resources.source;
            }
            else if (discipline == "Rainbow Six: Siege")
            {
                return Properties.Resources.r6;
            }
            else if (discipline == "Overwatch")
            {
                return Properties.Resources.over;
            }
            else if (discipline == "Warface")
            {
                return null;
            }
            else if (discipline == "Rocket League")
            {
                return null;
            }
            else if (discipline == "WOT")
            {
                return Properties.Resources.giphy;
            }
            else if (discipline == "PUBG")
            {
                return null;
            }
            else //"Apex Legends"
            {
                return null;
            }

        }

        public static Image setPict(string discipline)
        {
            /*if (discipline == "Dota 2")
            {*/
                return Properties.Resources.cyber_sport_neon__2_;
            /*}
            else if (discipline == "CS:GO")
            {
                return Properties.Resources;
            }
            else if (discipline == "LOL")
            {
                return Properties.Resources;
            }
            else if (discipline == "Valorant")
            {
                return Properties.Resources;
            }
            else if (discipline == "Smite")
            {
                return Properties.Resources;
            }
            else if (discipline == "COD")
            {
                return Properties.Resources;
            }
            else if (discipline == "Rainbow Six: Siege")
            {
                return Properties.Resources;
            }
            else if (discipline == "Overwatch")
            {
                return Properties.Resources;
            }
            else if (discipline == "Warface")
            {
                return Properties.Resources;
            }
            else if (discipline == "Rocket League")
            {
                return Properties.Resources;
            }
            else if (discipline == "WOT")
            {
                return Properties.Resources;
            }
            else if (discipline == "PUBG")
            {
                return Properties.Resources;
            }
            else //"Apex Legends"
            {
                return Properties.Resources;
            }
            
            return null;*/
        }
    }
}
