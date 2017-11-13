using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASP_WebCam.Models
{
    public class RobotModel
    {

        public int Counter { get; set; }
        public string Start { get; set; }
        public string YoutubeLink { get; set; }
        public string VideoFileE { get; set; }
        public string ChangeText = "What";
        public Image MyBitImage { get; set; }
        public string MyImagePath { get; set; }
        public byte[] ImageBytes { get; set; }

    }

    
}