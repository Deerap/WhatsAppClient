using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Whatsapp.Desktop.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string strBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string strMediaBasePath = strBasePath + @"\Media";
            Directory.CreateDirectory(strMediaBasePath);

            string strMediaProfilePictures = strMediaBasePath + @"\ProfilePictures";
            Directory.CreateDirectory(strMediaProfilePictures);

            string strMediaAudio = strMediaBasePath + @"\WhatsappAudio";
            Directory.CreateDirectory(strMediaAudio);

            string strMediaPictures = strMediaBasePath + @"\WhatsappPictures";
            Directory.CreateDirectory(strMediaPictures);

            string strMediaVideo = strMediaBasePath + @"\WhatsappVideo";
            Directory.CreateDirectory(strMediaVideo);
        }
    }
}
