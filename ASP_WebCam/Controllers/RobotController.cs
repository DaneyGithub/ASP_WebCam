using ASP_WebCam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace ASP_WebCam.Controllers
{
    public class RobotController : Controller
    {

        private FilterInfoCollection webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice cam;

        public ActionResult Webcam()
        {
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            return View("Index");
        }

        
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit;
            bit = (Bitmap)eventArgs.Frame.Clone();
           
            VideoInput cc;
            //cc=(VideoInput)eventArgs.Frame.Clone();
            MyLoad(bit);

        }

        public ActionResult MyLoad(Bitmap bit_map)
        {
           
            RobotModel nn = new RobotModel() { MyBitImage = bit_map };
            ViewBag.WHY = (byte[])new ImageConverter().ConvertTo(nn.MyBitImage, typeof(byte[]));
            //ViewBag.Vid = c;
            return View(nn);
        }

        
        // GET: Robot
        public ActionResult Index()
        {
            Webcam();
            return View();
        }

    }
}