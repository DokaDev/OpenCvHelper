using OpenCvSharp;

namespace OpenCvPractice.MotionDetection {
    public partial class MotionDetector {
        public Mat Detection(bool MorphView) {
            Mat morphElement = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(3, 3));
            Mat first = cam.GetFrame().CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat second = cam.GetFrame();
            Mat second_gray = second.CvtColor(ColorConversionCodes.BGR2GRAY);

            Mat diff = new(), morph = new();
            Cv2.Absdiff(first, second_gray, diff);
            Cv2.Threshold(diff, diff, 25, 255, ThresholdTypes.Binary);
            Cv2.MorphologyEx(diff, morph, MorphTypes.Open, morphElement);

            if(MorphView)
                Cv2.ImShow("morph", morph);

            Mat dst = morph.Clone();
            Cv2.CvtColor(dst, dst, ColorConversionCodes.GRAY2BGR);

            if (Cv2.CountNonZero(morph) > 5) {
                Contours.Contours contours = new();
                contours.FindContours(morph, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

                min_x = morph.Width; 
                max_x = 0;

                min_y = morph.Height;
                max_y = 0;

                foreach (var p in contours.contours) {
                    Rect boudningRect = Cv2.BoundingRect(p);

                    for(int i = 0; i < p.Length; i++) {
                        min_x = Math.Min(min_x, p[i].X);
                        min_y = Math.Min(min_y, p[i].Y);

                        max_x = Math.Max(max_x, p[i].X);
                        max_y = Math.Max(max_y, p[i].Y);
                    }
                }
                Cv2.Rectangle(dst, new Point(min_x, min_y), new Point(max_x, max_y), Scalar.Red, 2);
            }
            
            return dst;
        }
    }
}
