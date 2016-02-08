using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;
namespace FaceDetectCapt
{
    public partial class Form1 : Form
    {
        private Capture _capture = null;
        private Boolean processing;

        List<Rectangle> old_faces = new List<Rectangle>();
        List<Rectangle> old_eyes = new List<Rectangle>();

        public Form1()
        {
            InitializeComponent();
            try
            {
                _capture = new Capture();
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                processing = false;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (processing)
            {
                return;
            }
            processing = true;
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();

            long detectionTime;
            frame.Draw(new Rectangle(10, 10, 50, 50), new Bgr(Color.Cyan), 2);
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            DetectFace.Detect(frame, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);
            foreach (Rectangle face in faces)
                frame.Draw(face, new Bgr(Color.Red), 2);
            foreach (Rectangle eye in eyes)
                frame.Draw(eye, new Bgr(Color.Blue), 2);
            captureImageBox.Image = frame;
            Thread.Sleep(10);
            processing = false;
        }

    }
}
