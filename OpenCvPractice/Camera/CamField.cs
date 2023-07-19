using OpenCvSharp;

namespace OpenCvPractice.Camera {
    public partial class CameraCapture {
        private VideoCapture vc;

        private bool isDisposed { get; set; } = false;
        public int camNo { get; set; }
        public string camDir { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
