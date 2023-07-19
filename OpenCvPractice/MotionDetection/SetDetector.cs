using OpenCvPractice.Camera;

namespace OpenCvPractice.MotionDetection {
    public partial class MotionDetector {
        CameraCapture cam;
        public MotionDetector(CameraCapture cam) {
            this.cam = cam;
        }
    }
}
