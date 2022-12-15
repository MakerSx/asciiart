using System;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Mat = Emgu.CV.Mat;
using VideoCapture = Emgu.CV.VideoCapture;



//using AForge.Video.DirectShow;


namespace iText_version_1._05
{
    
    internal class Program
    {
       
       
        static void Main(string[] args)
        {
           

            string asciiChars = " .,:;asdfghjklşiqwertyuıopzxcvbnmöç-+*";

            
            var capture = new VideoCapture("D:\\Masaüstü\\vid3test.mp4");
            var img=new Mat();
            StringBuilder sb = new StringBuilder();
            while (capture.IsOpened)
            {
                capture.Read(img);
                if (img.Cols == 0) break;
                var bit = img.ToBitmap();
                var divideBy = img.Width / 100;
                var resized = new System.Drawing.Size(img.Width/divideBy,img.Height/divideBy);
                Bitmap bitResized = new(bit,resized);

                for (int i = 0; i < bitResized.Height; i++)
                {
                    for (int j = 0; j < bitResized.Width; j++)
                    {
                        var pixel = bitResized.GetPixel(j,i);
                        var avg = (pixel.R+pixel.G+pixel.B)/3;
                        sb.Append(asciiChars[avg*10/155%asciiChars.Length]);
                    }
                    sb.AppendLine();
                }

                Console.WriteLine(sb.ToString());
                Console.SetCursorPosition(0,0);
                sb.Clear();
            }
        }

        
    }
}
