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

       
        public void LoadMine()
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }
        public ActionResult Webcam()
        {
            Assign();
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            return View("Index");
        }

        
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
           // pictureBox1.Image = bit;
           
        }


        public ActionResult Assign()
        {
            RobotModel name = new RobotModel { Start = "Text through Model", VideoFileE= "Content/video.mp4" };
            return View(name);
        }
        
        // GET: Robot
        public ActionResult Index()
        {
            ViewBag.MyText = "Passing text from Conttoller to View";
            Assign();
            return View();
        }

        public ActionResult Start()
        {

          /* 
           * //the selected cam
           *cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();

            */
            Assign();
            return View("Index");
        }

        public ActionResult Stop()
        {
            Assign();
            return View("Index");
        }
    }
}