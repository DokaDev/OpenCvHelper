using OpenCvSharp;

namespace OpenCvPractice.Contours {
    public partial class Contours {
        public void FindContours(Mat mat, RetrievalModes mode, ContourApproximationModes method) {
            Mat tmp = mat.Clone();
            
            if(tmp.Type() !=  MatType.CV_8UC1) { Cv2.CvtColor(tmp, tmp, ColorConversionCodes.BGR2GRAY); }
                      
            Cv2.Threshold(tmp, tmp, 150, 255, ThresholdTypes.Otsu);
            Cv2.FindContours(tmp, out contours, out hierarchy, mode, method);
        }
    }
}
