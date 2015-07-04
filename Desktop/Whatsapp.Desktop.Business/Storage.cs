using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Whatsapp.Desktop.Business
{
    public class Storage
    {
        static Storage()
        {
            if (!Directory.Exists(AvatarDirectory))
                Directory.CreateDirectory(AvatarDirectory);
        }

        public static string AvatarDirectory
        {
            get
            {
                if (AppDomain.CurrentDomain.BaseDirectory.EndsWith(@"\"))
                    return AppDomain.CurrentDomain.BaseDirectory + @"cache\avatar\";
                else
                    return AppDomain.CurrentDomain.BaseDirectory + @"\cache\avatar\";
            }
        }

        public static string GetAvatar()
        {
            if (File.Exists(AvatarDirectory))
                return AvatarDirectory;
            else
                return "Images/profile/blank.png";
        }

        public static void SaveAvatar(byte[] data)
        {
            if (!File.Exists(AvatarDirectory))
                File.WriteAllBytes(Storage.AvatarDirectory, data);
        }
    }
}
