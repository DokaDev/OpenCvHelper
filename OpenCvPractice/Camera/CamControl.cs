using OpenCvSharp;

namespace OpenCvPractice.Camera {
    public partial class CameraCapture {
        public Mat GetFrame() {
            Mat tmp = new();
            vc.Read(tmp);
            width = vc.FrameWidth;
            height = vc.FrameHeight;
            return tmp;
        }

        public void WaitKey(int interval) {
            Cv2.WaitKey(interval);
        }
    }
}
