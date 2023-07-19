using OpenCvSharp;
using OpenCvPractice.Camera;

namespace OpenCvPractice.MotionDetection {
    public partial class MotionDetector {
        Camera.CameraCapture cam;
        public MotionDetector(Camera.CameraCapture cam) {
            this.cam = cam;
        }
    }
}
